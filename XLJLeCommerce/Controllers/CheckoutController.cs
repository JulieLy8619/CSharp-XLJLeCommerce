using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Interfaces;
using XLJLeCommerce.Models.ViewModels;

namespace XLJLeCommerce.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrder _order;
        private readonly IShoppingCartItem _shoppingCartItem;
        private readonly ICart _cart;
        private readonly IOrderedItems _ordereditems;
        private IEmailSender _emailSender;
        private UserManager<ApplicationUser> _userManager;

        public CheckoutController(ICart cart, IShoppingCartItem shoppingCartItem, IOrder order, UserManager<ApplicationUser> userManager, IOrderedItems ordereditems, IEmailSender emailSender)
        {
            _ordereditems = ordereditems;
            _cart = cart;
            _order = order;
            _shoppingCartItem = shoppingCartItem;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        /// <summary>
        /// calls the main default page
        /// </summary>
        /// <returns>the page</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// does the check out (like make a receipt page, send a receipt email)
        /// </summary>
        /// <returns>a page after it's done</returns>
        [HttpPost]
        public async Task<IActionResult> Review()
        {
            //get user ID
            string userEmail = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userEmail);
            string userID = user.Id;

            //create order
            Order ord = new Order();
            ord.UserID = userID;
           

            //move all shopping items in cart to order items
                //find their carts
            Cart cartObj = await _cart.GetCart(userID);
                //get all the items in the cart
            IEnumerable<ShoppingCartItem> cartitems = await _shoppingCartItem.GetAllShoppingCartItems(cartObj.ID);
            decimal totalprice = 0m;
            //convert it to orderitem
            foreach (var item in cartitems)
            {
                OrderedItems tempOrdItem = new OrderedItems();
                tempOrdItem.OrderID = ord.ID;
                tempOrdItem.ShoppingCartItemID = item.ID;

                await _ordereditems.CreateOrderedItem(tempOrdItem);
                //then delete it from shopping cart or wait to do this when we pay
                totalprice += (item.ProdQty * item.Product.Price);
            }

            ord.Totalprice = totalprice;
            await _order.CreateOrder(ord);
            List<OrderedItems> ordedItems = await _ordereditems.GetAllOrderedItems(ord.ID);
            string emailMessage = ReceiptEmailBuilder(ord, ordedItems).ToString() ;
            await _emailSender.SendEmailAsync(userEmail, "Receipt for Mystical Creatures", emailMessage);
           return View(await _ordereditems.GetAllOrderedItems(ord.ID));

        }

        /// <summary>
        /// helper function to build the message for receipt
        /// </summary>
        /// <param name="order">the order</param>
        /// <param name="ordItems">all the items in the order</param>
        /// <returns>the message to put in the email</returns>
        public string ReceiptEmailBuilder(Order order, List<OrderedItems> ordItems)
        {
            string returnMessage = $"Confirmation number {order.ID}{order.UserID} <br /> You ordered: <br />";
            //iterate through ordered items looking for order number
            //then for each of those, put that in the message
            //List<OrderedItems> ordedItems = await _ordereditems.GetAllOrderedItems(order.ID);

            int total = 0;

            foreach (OrderedItems item in ordItems)
            {
                string nameString = item.ShoppingCartItem.Product.Name;
                string priceString = item.ShoppingCartItem.Product.Price.ToString();
                decimal priceDeci = item.ShoppingCartItem.Product.Price;
                string qtyString = item.ShoppingCartItem.ProdQty.ToString();
                int qtyInt = item.ShoppingCartItem.ProdQty;
                total = total + (Convert.ToInt32(priceDeci) * qtyInt);
                returnMessage = returnMessage + $"{qtyString} {nameString} at {priceString} <br />";
            }
            returnMessage = returnMessage + $" totals: <br /> {total} <br /> Please consider this your receipt. Thank you for your purchase. <br /> Sincerely, <br /> The Mystical Creatures Team";

            return returnMessage;
        }

        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentViewModel pvm)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = "62k7pMQ3",
                ItemElementName = ItemChoiceType.transactionKey,
                Item = "946enQkPzJw59v2Z"
            };

            var creditCard = new creditCardType
            {
                cardNumber = pvm.CardNumber,
                expirationDate = pvm.ExpDate
            };

         
            customerAddressType billingAddress = new customerAddressType()
            {   firstName=pvm.FirstName,
                lastName = pvm.LastName,
                address = pvm.Address,
                zip = pvm.ZipCode
            };

            string userEmail = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userEmail);
            string userID = user.Id;
            Order ord = new Order();
            ord.UserID = userID;
            await _order.CreateOrder(ord);
            Cart cartObj = await _cart.GetCart(userID);
            //get all the items in the cart
            IEnumerable<ShoppingCartItem> cartitems = await _shoppingCartItem.GetAllShoppingCartItems(cartObj.ID);
            decimal totalprice = 0m;
            //convert it to orderitem
            foreach (var item in cartitems)
            {
                OrderedItems tempOrdItem = new OrderedItems();
                tempOrdItem.OrderID = ord.ID;
                tempOrdItem.ShoppingCartItemID = item.ID;

                await _ordereditems.CreateOrderedItem(tempOrdItem);
                //then delete it from shopping cart or wait to do this when we pay
                totalprice += (item.ProdQty * item.Product.Price);
            }

            ord.Totalprice = totalprice;
         
            paymentType paymentType = new paymentType { Item = creditCard };

            transactionRequestType transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount=ord.Totalprice,
                payment = paymentType,
                billTo = billingAddress,
            };

            createTransactionRequest request = new createTransactionRequest
            {
                transactionRequest = transactionRequest
            };

            // make a call out to AUth.NET with the requset we just created
            var controller = new createTransactionController(request);
            // execute the call
            controller.Execute();

            // this is the reseponse from the call we made above. 
            var response = controller.GetApiResponse();

            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    if (response.transactionResponse != null)
                    {
                        return RedirectToAction("Receipt", "Checkout");
                    }
                }
                else
                {
                    return View();
                }
            }

            return View();

        }


        [HttpGet]
        public async Task<IActionResult> Receipt()
        {
            string userEmail = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userEmail);
            string userID = user.Id;
            Order ord = new Order();
            ord.UserID = userID;
            await _order.CreateOrder(ord);
            Cart cartObj = await _cart.GetCart(userID);
            //get all the items in the cart
            IEnumerable<ShoppingCartItem> cartitems = await _shoppingCartItem.GetAllShoppingCartItems(cartObj.ID);
            decimal totalprice = 0m;
            //convert it to orderitem
            foreach (var item in cartitems)
            {
                OrderedItems tempOrdItem = new OrderedItems();
                tempOrdItem.OrderID = ord.ID;
                tempOrdItem.ShoppingCartItemID = item.ID;

                await _ordereditems.CreateOrderedItem(tempOrdItem);
                //then delete it from shopping cart or wait to do this when we pay
                totalprice += (item.ProdQty * item.Product.Price);
                await _shoppingCartItem.DeleteShoppingCartItem(item.ID);
            }

            ord.Totalprice = totalprice;
           
            return View(ord);

        }

    }
}
