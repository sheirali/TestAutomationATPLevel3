using DesignPatternsTests.Pages.Sections;
using DesignPatternsTests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPatternsTests.Pages
{
    public partial class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) :
            base(driver)
        {
        }

        public override string Url => "http://demos.bellatrix.solutions/checkout/";

        public MenuSection MainMenu => new MenuSection(Driver);
        public SearchSection SearchProduct => new SearchSection(Driver);
        public ViewCartSection ViewCart => new ViewCartSection(Driver);
        public BreadcrumbSection Breadcrumb => new BreadcrumbSection(Driver);


        private IWebElement FirstNameText => FindClickableElement(By.Id("billing_first_name"));
        private IWebElement LastNameText => FindClickableElement(By.Id("billing_last_name"));
        private IWebElement CompanyNameText => FindClickableElement(By.Id("billing_company"));
        private IWebElement CountryDropDown => FindClickableElement(By.Id("billing_country"));//once set, ajax wait
        private IWebElement AddressLine1Text => FindClickableElement(By.Id("billing_address_1"));
        private IWebElement AddressLine2Text => FindClickableElement(By.Id("billing_address_2"));
        private IWebElement CityText => FindClickableElement(By.Id("billing_city"));
        private IWebElement StateDropDown => FindClickableElement(By.Id("billing_state"));//ajax wait after Country set
        private IWebElement PostalCodeText => FindClickableElement(By.Id("billing_postcode"));
        private IWebElement PhoneNumberText => FindClickableElement(By.Id("billing_phone"));
        private IWebElement EmailAddressText => FindClickableElement(By.Id("billing_email"));
        private IWebElement OrderNotesText => FindClickableElement(By.Id("order_comments"));
        private IWebElement CreateAccountCheckbox => FindClickableElement(By.Id("createaccount"));
        private IWebElement PlaceOrderButton => FindClickableElement(By.Id("place_order"));

        private IWebElement TotalText => FindElement(By.XPath("//span[@class='woocommerce-Price-amount amount']/bdi[last()]"));

        public void PopulateBillingInfo(BillingDetailItem purchaser)
        {
            if (purchaser == null)
            {
                return;
            }

            SetBillingTextInfo(this.FirstNameText, purchaser.FirstName);
            SetBillingTextInfo(this.LastNameText, purchaser.LastName);
            SetBillingTextInfo(this.CompanyNameText, purchaser.CompanyName);
            SetBillingTextInfo(this.AddressLine1Text, purchaser.AddressLine1);
            SetBillingTextInfo(this.AddressLine2Text, purchaser.AddressLine2);
            SetBillingTextInfo(this.CityText, purchaser.City);
            SetBillingTextInfo(this.PostalCodeText, purchaser.PostalCode);
            SetBillingTextInfo(this.PhoneNumberText, purchaser.PhoneNumber);
            SetBillingTextInfo(this.EmailAddressText, purchaser.EmailAddress);
            SetBillingTextInfo(this.OrderNotesText, purchaser.OrderNotes);

            SetBillingDropdownInfo(this.CountryDropDown, purchaser.Country);
            WaitForAjax();

            SetBillingDropdownInfo(this.StateDropDown, purchaser.State);
            WaitForAjax();


            if (purchaser.CreateAccount && !this.CreateAccountCheckbox.Selected)
            {
                Debug.WriteLine("CheckoutPage.PopulateBillingInfo() -- call CreateAccountCheckbox.Click");
                CreateAccountCheckbox.Click();
                WaitForAjax();
            }
        }

        private void SetBillingDropdownInfo(IWebElement dropDownElement, string value)
        {
            //https://www.selenium.dev/documentation/en/support_packages/working_with_select_elements/

            if (dropDownElement == null || string.IsNullOrEmpty(value))
            {
                return;
            }

            var selectObject = new SelectElement(dropDownElement);
            selectObject.SelectByText(value);
        }

        private void SetBillingTextInfo(IWebElement inputElement, string value)
        {
            inputElement?.Clear();
            inputElement?.SendKeys(value);
        }

        public void PlaceOrder()
        {
            Debug.WriteLine("CheckoutPage.PlaceOrder() -- call PlaceOrderButton.Click");
            WaitForAjax();
            this.PlaceOrderButton?.Click();
        }

        public string GetTotal => this.TotalText.Text;
    }
}
