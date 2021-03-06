﻿using System;
using BraintreeDropIn;
using BraintreeCore;
using BraintreeUIKit;
using BraintreeUnionPay;
using Foundation;
using ObjCRuntime;
using UIKit;
using BraintreePayPal;
using BraintreePaymentFlow;
using BraintreeCard;

namespace BraintreeDropIn
{
    //[Static]
    //[Verify (ConstantsInterfaceAssociation)]
    //partial interface Constants
    //{
    //	// extern double BraintreeDropInVersionNumber;
    //	[Field ("BraintreeDropInVersionNumber", "__Internal")]
    //	double BraintreeDropInVersionNumber { get; }

    //	// extern const unsigned char [] BraintreeDropInVersionString;
    //	[Field ("BraintreeDropInVersionString", "__Internal")]
    //	byte[] BraintreeDropInVersionString { get; }
    //}

    // @interface BTDropInBaseViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface BTDropInBaseViewController
    {
        // -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient request:(BTDropInRequest * _Nonnull)request;
        [Export("initWithAPIClient:request:")]
        IntPtr Constructor(BTAPIClient apiClient, BTDropInRequest request);

        // @property (nonatomic, strong) BTAPIClient * _Nonnull apiClient;
        [Export("apiClient", ArgumentSemantic.Strong)]
        BTAPIClient ApiClient { get; set; }

        // @property (nonatomic, strong) BTConfiguration * _Nullable configuration;
        [NullAllowed, Export("configuration", ArgumentSemantic.Strong)]
        BTConfiguration Configuration { get; set; }

        // -(void)configurationLoaded:(BTConfiguration * _Nonnull)configuration error:(NSError * _Nonnull)error;
        [Export("configurationLoaded:error:")]
        void ConfigurationLoaded(BTConfiguration configuration, NSError error);

        // -(void)loadConfiguration;
        [Export("loadConfiguration")]
        void LoadConfiguration();

        // @property (nonatomic, strong) BTDropInRequest * _Nullable dropInRequest;
        [NullAllowed, Export("dropInRequest", ArgumentSemantic.Strong)]
        BTDropInRequest DropInRequest { get; set; }

        // -(void)showLoadingScreen:(BOOL)show;
        [Export("showLoadingScreen:")]
        void ShowLoadingScreen(bool show);
    }

    // @interface BTCardFormViewController : BTDropInBaseViewController <UITextFieldDelegate, BTUIKFormFieldDelegate, BTUIKCardNumberFormFieldDelegate>
    [BaseType(typeof(BTDropInBaseViewController))]
    interface BTCardFormViewController : IUITextFieldDelegate, IBTUIKFormFieldDelegate, IBTUIKCardNumberFormFieldDelegate
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        NSObject Delegate { get; set; }

        // @property (nonatomic, weak) id<BTCardFormViewControllerDelegate,BTDropInControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) BTUIKCardNumberFormField * _Nonnull cardNumberField;
        [Export("cardNumberField", ArgumentSemantic.Strong)]
        BTUIKCardNumberFormField CardNumberField { get; }

        // @property (readonly, nonatomic, strong) BTUIKCardholderNameFormField * _Nonnull cardholderNameField;
        [Export("cardholderNameField", ArgumentSemantic.Strong)]
        BTUIKCardholderNameFormField CardholderNameField { get; }

        // @property (readonly, nonatomic, strong) BTUIKExpiryFormField * _Nonnull expirationDateField;
        [Export("expirationDateField", ArgumentSemantic.Strong)]
        BTUIKExpiryFormField ExpirationDateField { get; }

        // @property (readonly, nonatomic, strong) BTUIKSecurityCodeFormField * _Nonnull securityCodeField;
        [Export("securityCodeField", ArgumentSemantic.Strong)]
        BTUIKSecurityCodeFormField SecurityCodeField { get; }

        // @property (readonly, nonatomic, strong) BTUIKPostalCodeFormField * _Nonnull postalCodeField;
        [Export("postalCodeField", ArgumentSemantic.Strong)]
        BTUIKPostalCodeFormField PostalCodeField { get; }

        // @property (readonly, nonatomic, strong) BTUIKMobileCountryCodeFormField * _Nonnull mobileCountryCodeField;
        [Export("mobileCountryCodeField", ArgumentSemantic.Strong)]
        BTUIKMobileCountryCodeFormField MobileCountryCodeField { get; }

        // @property (readonly, nonatomic, strong) BTUIKMobileNumberFormField * _Nonnull mobilePhoneField;
        [Export("mobilePhoneField", ArgumentSemantic.Strong)]
        BTUIKMobileNumberFormField MobilePhoneField { get; }

        // @property (readonly, nonatomic, strong) BTCardRequest * _Nullable cardRequest;
        [NullAllowed, Export("cardRequest", ArgumentSemantic.Strong)]
        BTCardRequest CardRequest { get; }

        // @property (readonly, nonatomic, strong) BTCardCapabilities * _Nullable cardCapabilities;
        [NullAllowed, Export("cardCapabilities", ArgumentSemantic.Strong)]
        BTCardCapabilities CardCapabilities { get; }

        // @property (copy, nonatomic) NSArray * _Nonnull supportedCardTypes;
        [Export("supportedCardTypes", ArgumentSemantic.Copy)]
        NSObject[] SupportedCardTypes { get; set; }

        // -(void)resetForm;
        [Export("resetForm")]
        void ResetForm();
    }

    // @protocol BTCardFormViewControllerDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BTCardFormViewControllerDelegate
    {
        // @required -(void)cardTokenizationCompleted:(BTPaymentMethodNonce * _Nullable)tokenizedCard error:(NSError * _Nullable)error sender:(BTCardFormViewController * _Nonnull)sender;
        [Abstract]
        [Export("cardTokenizationCompleted:error:sender:")]
        void Error([NullAllowed] BTPaymentMethodNonce tokenizedCard, [NullAllowed] NSError error, BTCardFormViewController sender);
    }

    // @interface BTDropInResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BTDropInResult
    {
        // @property (getter = isCancelled, assign, nonatomic) BOOL cancelled;
        [Export("cancelled")]
        bool Cancelled { [Bind("isCancelled")] get; set; }

        // @property (assign, nonatomic) BTUIKPaymentOptionType paymentOptionType;
        [Export("paymentOptionType", ArgumentSemantic.Assign)]
        BTUIKPaymentOptionType PaymentOptionType { get; set; }

        // @property (readonly, nonatomic) UIView * _Nonnull paymentIcon;
        [Export("paymentIcon")]
        UIView PaymentIcon { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull paymentDescription;
        [Export("paymentDescription")]
        string PaymentDescription { get; }

        // @property (nonatomic, strong) BTPaymentMethodNonce * _Nullable paymentMethod;
        [NullAllowed, Export("paymentMethod", ArgumentSemantic.Strong)]
        BTPaymentMethodNonce PaymentMethod { get; set; }

        // +(void)fetchDropInResultForAuthorization:(NSString * _Nonnull)authorization handler:(BTDropInResultFetchHandler _Nonnull)handler;
        [Static]
        [Export("fetchDropInResultForAuthorization:handler:")]
        void FetchDropInResultForAuthorization(string authorization, BTDropInResultFetchHandler handler);
    }

    // typedef void (^BTDropInResultFetchHandler)(BTDropInResult * _Nullable, NSError * _Nullable);
    delegate void BTDropInResultFetchHandler([NullAllowed] BTDropInResult arg0, [NullAllowed] NSError arg1);

    // @interface BTDropInRequest : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface BTDropInRequest : INSCopying
    {
        // @property (nonatomic, strong) BTPayPalRequest * _Nullable payPalRequest;
        [NullAllowed, Export("payPalRequest", ArgumentSemantic.Strong)]
        BTPayPalRequest PayPalRequest { get; set; }

        // @property (assign, nonatomic) BOOL applePayDisabled;
        [Export("applePayDisabled")]
        bool ApplePayDisabled { get; set; }

        // @property (assign, nonatomic) BOOL paypalDisabled;
        [Export("paypalDisabled")]
        bool PaypalDisabled { get; set; }

        // @property (assign, nonatomic) BOOL venmoDisabled;
        [Export("venmoDisabled")]
        bool VenmoDisabled { get; set; }

        // @property (assign, nonatomic) BOOL cardDisabled;
        [Export("cardDisabled")]
        bool CardDisabled { get; set; }

        // @property (assign, nonatomic) BOOL threeDSecureVerification;
        [Export("threeDSecureVerification")]
        bool ThreeDSecureVerification { get; set; }

        // @property (nonatomic, strong) BTThreeDSecureRequest * _Nullable threeDSecureRequest;
        [NullAllowed, Export("threeDSecureRequest", ArgumentSemantic.Strong)]
        BTThreeDSecureRequest ThreeDSecureRequest { get; set; }

        // @property (assign, nonatomic) BTFormFieldSetting cardholderNameSetting;
        [Export("cardholderNameSetting", ArgumentSemantic.Assign)]
        BTFormFieldSetting CardholderNameSetting { get; set; }

        // @property (assign, nonatomic) BOOL shouldMaskSecurityCode;
        [Export("shouldMaskSecurityCode")]
        bool ShouldMaskSecurityCode { get; set; }

        // @property (assign, nonatomic) BOOL vaultManager;
        [Export("vaultManager")]
        bool VaultManager { get; set; }

        // @property (assign, nonatomic) BOOL vaultCard;
        [Export("vaultCard")]
        bool VaultCard { get; set; }

        // @property (assign, nonatomic) BOOL allowVaultCardOverride;
        [Export("allowVaultCardOverride")]
        bool AllowVaultCardOverride { get; set; }
    }

    // @interface BTPaymentSelectionViewController : BTDropInBaseViewController <UICollectionViewDataSource, UICollectionViewDelegate, UICollectionViewDelegateFlowLayout, UITableViewDataSource, UITableViewDelegate>
    [BaseType(typeof(BTDropInBaseViewController))]
    interface BTPaymentSelectionViewController : IUICollectionViewDataSource, IUICollectionViewDelegate, IUICollectionViewDelegateFlowLayout, IUITableViewDataSource, IUITableViewDelegate
    {
        // @property (nonatomic, strong) NSArray * paymentMethodNonces;
        [Export("paymentMethodNonces", ArgumentSemantic.Strong)]
        NSObject[] PaymentMethodNonces { get; set; }

        [Wrap("WeakDelegate")]
        NSObject Delegate { get; set; }

        // @property (nonatomic, weak) id<BTPaymentSelectionViewControllerDelegate,BTDropInControllerDelegate,BTAppSwitchDelegate,BTViewControllerPresentingDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(float)sheetHeight;
        [Export("sheetHeight")]
        float SheetHeight { get; }
    }

    // @protocol BTPaymentSelectionViewControllerDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BTPaymentSelectionViewControllerDelegate
    {
        // @required -(void)selectionCompletedWithPaymentMethodType:(BTUIKPaymentOptionType)type nonce:(BTPaymentMethodNonce *)nonce error:(NSError *)error;
        [Abstract]
        [Export("selectionCompletedWithPaymentMethodType:nonce:error:")]
        void SelectionCompletedWithPaymentMethodType(BTUIKPaymentOptionType type, BTPaymentMethodNonce nonce, NSError error);

        // @required -(void)sheetHeightDidChange:(BTPaymentSelectionViewController *)sender;
        [Abstract]
        [Export("sheetHeightDidChange:")]
        void SheetHeightDidChange(BTPaymentSelectionViewController sender);
    }

    // @interface BTDropInController : UIViewController <UIToolbarDelegate, UIViewControllerTransitioningDelegate>
    [BaseType(typeof(UIViewController))]
    interface BTDropInController : IUIToolbarDelegate, IUIViewControllerTransitioningDelegate
    {
        // -(instancetype _Nullable)initWithAuthorization:(NSString * _Nonnull)authorization request:(BTDropInRequest * _Nonnull)request handler:(BTDropInControllerHandler _Nullable)handler;
        [Export("initWithAuthorization:request:handler:")]
        IntPtr Constructor(string authorization, BTDropInRequest request, [NullAllowed] BTDropInControllerHandler handler);

        // @property (readonly, nonatomic, strong) BTAPIClient * _Nonnull apiClient;
        [Export("apiClient", ArgumentSemantic.Strong)]
        BTAPIClient ApiClient { get; }

        // @property (readonly, nonatomic, strong) BTDropInRequest * _Nonnull dropInRequest;
        [Export("dropInRequest", ArgumentSemantic.Strong)]
        BTDropInRequest DropInRequest { get; }

        // -(void)showCardForm:(id _Nonnull)sender;
        [Export("showCardForm:")]
        void ShowCardForm(NSObject sender);
    }

    // typedef void (^BTDropInControllerHandler)(BTDropInController * _Nonnull, BTDropInResult * _Nullable, NSError * _Nullable);
    delegate void BTDropInControllerHandler(BTDropInController arg0, [NullAllowed] BTDropInResult arg1, [NullAllowed] NSError arg2);

    // @protocol BTDropInControllerDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface BTDropInControllerDelegate
    {
        // @required -(void)reloadDropInData;
        [Abstract]
        [Export("reloadDropInData")]
        void ReloadDropInData();

        // @required -(void)editPaymentMethods:(id _Nonnull)sender;
        [Abstract]
        [Export("editPaymentMethods:")]
        void EditPaymentMethods(NSObject sender);
    }

    // @interface BTVaultManagementViewController : BTDropInBaseViewController <UITableViewDataSource, UITableViewDelegate>
    [BaseType(typeof(BTDropInBaseViewController))]
    interface BTVaultManagementViewController : IUITableViewDataSource, IUITableViewDelegate
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        BTDropInControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BTDropInControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }
}
