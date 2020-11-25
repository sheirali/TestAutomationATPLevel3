using DemoPageTests.Pages.Sections;
using DemoPageTests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using Unicorn.Web;
using Unicorn.Web.Pages;

namespace DemoPageTests.Pages
{
    public partial class CheckoutPage : Page
    {
        public CheckoutPage()
        {
            ////Url = new Uri("http://demos.bellatrix.solutions/checkout/");
        }

        ////public override string Url => "http://demos.bellatrix.solutions/checkout/";
        ////public MenuSection MainMenu => new MenuSection(Driver);
        ////public SearchSection SearchProduct => new SearchSection(Driver);
        ////public ViewCartSection ViewCart => new ViewCartSection(Driver);
        ////public BreadcrumbSection Breadcrumb => new BreadcrumbSection(Driver);

        public TextField FirstNameText => ElementCreateService.CreateById<TextField>("billing_first_name");
        public TextField LastNameText => ElementCreateService.CreateById<TextField>("billing_last_name");
        public TextField CompanyNameText => ElementCreateService.CreateById<TextField>("billing_company");
        public TextField AddressLine1Text => ElementCreateService.CreateById<TextField>("billing_address_1");
        public TextField AddressLine2Text => ElementCreateService.CreateById<TextField>("billing_address_2");
        public TextField CityText => ElementCreateService.CreateById<TextField>("billing_city");
        public TextField PostalCodeText => ElementCreateService.CreateById<TextField>("billing_postcode");
        public TextField PhoneNumberText => ElementCreateService.CreateById<TextField>("billing_phone");
        public TextField EmailAddressText => ElementCreateService.CreateById<TextField>("billing_email");
        public TextField OrderNotesText => ElementCreateService.CreateById<TextField>("order_comments");
        public TextField TotalText => ElementCreateService.CreateByXPath<TextField>("//span[@class='woocommerce-Price-amount amount']/bdi[last()]");
        public Select CountryDropDown => ElementCreateService.CreateById<Select>("billing_country"); // once set, ajax wait
        public Select StateDropDown => ElementCreateService.CreateById<Select>("billing_state"); // once set, ajax wait
        public CheckBox CreateAccountCheckbox => ElementCreateService.CreateById<CheckBox>("createaccount");
        public Button PlaceOrderButton => ElementCreateService.CreateById<Button>("place_order");

        public void PopulateBillingInfo(BillingDetailItem purchaser)
        {
            if (purchaser == null)
            {
                return;
            }

            SetBillingTextInfo(FirstNameText, purchaser.FirstName);
            SetBillingTextInfo(LastNameText, purchaser.LastName);
            SetBillingTextInfo(CompanyNameText, purchaser.CompanyName);
            SetBillingTextInfo(AddressLine1Text, purchaser.AddressLine1);
            SetBillingTextInfo(AddressLine2Text, purchaser.AddressLine2);
            SetBillingTextInfo(CityText, purchaser.City);
            SetBillingTextInfo(PostalCodeText, purchaser.PostalCode);
            SetBillingTextInfo(PhoneNumberText, purchaser.PhoneNumber);
            SetBillingTextInfo(EmailAddressText, purchaser.EmailAddress);
            SetBillingTextInfo(OrderNotesText, purchaser.OrderNotes);

            SetBillingDropdownInfo(CountryDropDown, purchaser.Country);
            WaitForAjax();

            SetBillingDropdownInfo(StateDropDown, purchaser.State);
            WaitForAjax();

            if (purchaser.CreateAccount && !CreateAccountCheckbox.Checked)
            {
                Debug.WriteLine("CheckoutPage.PopulateBillingInfo() -- call CreateAccountCheckbox.Click");
                CreateAccountCheckbox.Check();
                WaitForAjax();
            }
        }

        private void SetBillingDropdownInfo(Select dropDownElement, string value)
        {
            // https://www.selenium.dev/documentation/en/support_packages/working_with_select_elements/
            if (dropDownElement == null || string.IsNullOrEmpty(value))
            {
                return;
            }

            dropDownElement.SelectByText(value);
            ////var selectObject = new SelectElement(dropDownElement);
            ////selectObject.SelectByText(value);
        }

        private void SetBillingTextInfo(TextField inputElement, string value)
        {
            inputElement?.TypeText(value);
        }

        public void PlaceOrder()
        {
            Debug.WriteLine("CheckoutPage.PlaceOrder() -- call PlaceOrderButton.Click");
            WaitForAjax();
            PlaceOrderButton?.Click();
        }

        public void WaitForAjax()
        {
            BrowserService.WaitForAjax();
        }

        ////public override void WaitForPageToLoad()
        ////{
        ////    BrowserService.WaitUntilPageLoadsCompletely();
        ////}

        public string GetTotal => TotalText.InnerText;

        ////public override Uri Url { get; set; }
    }
}
