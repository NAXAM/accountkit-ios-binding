using System;
using Foundation;
using UIKit;
using ObjCRuntime;

namespace Facebook.Accountkit
{
	[Static]
	// [Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const NSUInteger AKFButtonTypeCount;
		[Field ("AKFButtonTypeCount", "__Internal")]
		nuint AKFButtonTypeCount { get; }

		// extern const NSUInteger AKFLoginFlowStateCount;
		[Field ("AKFLoginFlowStateCount", "__Internal")]
		nuint AKFLoginFlowStateCount { get; }

		// extern const NSUInteger AKFTextPositionCount;
		[Field ("AKFTextPositionCount", "__Internal")]
		nuint AKFTextPositionCount { get; }

		// extern const NSUInteger AKFHeaderTextTypeCount;
		[Field ("AKFHeaderTextTypeCount", "__Internal")]
		nuint AKFHeaderTextTypeCount { get; }
	}

	// typedef void (^AKFRequestAccountHandler)(id<AKFAccount> _Nullable, NSError * _Nullable);
	delegate void AKFRequestAccountHandler ([NullAllowed] AKFAccount arg0, [NullAllowed] NSError arg1);

	[Static]
	// [Verify (ConstantsInterfaceAssociation)]
	partial interface AKFError
	{
		// extern NSString *const _Nonnull AKFErrorDomain;
		[Field ("AKFErrorDomain", "__Internal")]
		NSString Domain { get; }

		// extern NSString *const _Nonnull AKFErrorDeveloperMessageKey;
		[Field ("AKFErrorDeveloperMessageKey", "__Internal")]
		NSString DeveloperMessageKey { get; }

		// extern NSString *const _Nonnull AKFErrorUserMessageKey;
		[Field ("AKFErrorUserMessageKey", "__Internal")]
		NSString UserMessageKey { get; }

		// extern NSString *const _Nonnull AKFErrorObjectKey;
		[Field ("AKFErrorObjectKey", "__Internal")]
		NSString ObjectKey { get; }
	}

	[Static]
	// [Verify (ConstantsInterfaceAssociation)]
	partial interface AKFServerError
	{
		// extern NSString *const _Nonnull AKFServerErrorDomain;
		[Field ("AKFServerErrorDomain", "__Internal")]
		NSString Domain { get; }
	}

	//@protocol AKFAccessToken <NSObject, NSCopying, NSSecureCoding>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	partial interface AKFAccessToken : INSCopying, INSSecureCoding 
	{
		//@property (nonatomic, copy, readonly) NSString *accountID;
		[Abstract, Export("accountID", ArgumentSemantic.Copy)]
		string AccountId { get; }
		
		//@property (nonatomic, copy, readonly) NSString *applicationID;
		[Abstract, Export("applicationID", ArgumentSemantic.Copy)]
		string ApplicationId { get; }
		
		//@property (nonatomic, copy, readonly) NSDate *lastRefresh;
		[Abstract, Export("lastRefresh", ArgumentSemantic.Copy)]
		NSDate LastRefresh { get; }
		
		//@property (nonatomic, readonly, assign) NSTimeInterval tokenRefreshInterval;
		[Abstract, Export("tokenRefreshInterval", ArgumentSemantic.Assign)]
		float TokenRefreshInterval { get; }
		
		//@property (nonatomic, readonly, copy) NSString *tokenString;
		[Export("tokenString", ArgumentSemantic.Copy)]
		string TokenString { get; }
	}

	//@protocol AKFAccount <NSObject, NSCopying, NSSecureCoding>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	partial interface AKFAccount : INSCopying, INSSecureCoding 
	{
		//@property (nonatomic, readonly, copy) NSString *accountID;
		[Abstract, Export("accountID", ArgumentSemantic.Copy)]
		string AccountId { get; }
		
		//@property (nullable, nonatomic, readonly, copy) NSString *emailAddress;
		[Abstract, Export("emailAddress", ArgumentSemantic.Copy)]
		string EmailAddress { get; }
		
		//property (nullable, nonatomic, readonly, copy) AKFPhoneNumber *phoneNumber;
		[Abstract, Export("phoneNumber", ArgumentSemantic.Copy)]
		AKFPhoneNumber PhoneNumber { get; }
	}

	//@interface AKFAccountKit : NSObject
	[BaseType(typeof(NSObject))]
	partial interface AKFAccountKit
	{
		//+ (NSString *)graphVersionString;
		[Static, Export("graphVersionString")]
		string GraphVersionString { get; }

		//+ (NSString *)versionString;
		[Static, Export("versionString")]
		string VersionString { get; }

		//@property (nullable, nonatomic, copy, readonly) id<AKFAccessToken> currentAccessToken;
		[NullAllowed, Export("currentAccessToken", ArgumentSemantic.Copy)]
		NSObject CurrentAccessToken { get; }

		//- (instancetype)initWithResponseType:(AKFResponseType)responseType NS_DESIGNATED_INITIALIZER;
		[Export("initWithResponseType:")]
		IntPtr Constructor(AKFResponseType responseType);

		//- (nullable AKFAccountPreferences *)accountPreferences;
		[NullAllowed, Export("accountPreferences")]
		AKFAccountPreferences AccountPreferences { get; set; }

		//- (void)cancelLogin;
		[Export("cancelLogin")]
		void CancelLogin();

		//- (void)logOut;
		[Export("logOut")]
		void LogOut();

		//- (void)requestAccount:(AKFRequestAccountHandler)handler;
		[Export("requestAccount:")]
		void RequestAccount(AKFRequestAccountHandler handler);

		//- (UIViewController<AKFViewController> *)viewControllerForEmailLogin;
		[Export("viewControllerForEmailLogin")]
		UIViewController ViewControllerForEmailLogin();

		// - (UIViewController<AKFViewController> *)viewControllerForEmailLoginWithEmail:(nullable NSString *)email state:(nullable NSString *)state;
		[Export("viewControllerForEmailLoginWithEmail:state:")]
		UIViewController ViewControllerForEmailLoginWithEmail(string email, string state);

		//- (UIViewController<AKFViewController> *)viewControllerForPhoneLogin;
		[Export("viewControllerForPhoneLogin")]
		UIViewController ViewControllerForPhoneLogin();

		//- (UIViewController<AKFViewController> *)viewControllerForPhoneLoginWithPhoneNumber:(nullable AKFPhoneNumber *)phoneNumber state:(nullable NSString *)state;
		[Export("viewControllerForPhoneLoginWithPhoneNumber:state:")]
		UIViewController ViewControllerForPhoneLoginWithPhoneNumber(AKFPhoneNumber phoneNumber, string state);

		//- (nullable UIViewController<AKFViewController> *)viewControllerForLoginResume;
		[Export("ViewControllerForLoginResume")]
		void ViewControllerForLoginResume();
	}

	//@interface AKFAccountPreferences : NSObject
	[BaseType(typeof(NSObject))]
	partial interface AKFAccountPreferences 
	{
		//@property (nonatomic, weak) id<AKFAccountPreferencesDelegate> delegate;
		[Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		//- (void)deletePreferenceForKey:(NSString *)key;
		[Export("deletePreferenceForKey:")]
		void DeletePreferenceForKey(string key);

		//- (void)loadPreferenceForKey:(NSString *)key;
		[Export("loadPreferenceForKey:")]
		void LoadPreferenceForKey(string key);

		//- (void)loadPreferences;
		[Export("loadPreferences")]
		void LoadPreferences();

		//- (void)setPreferenceForKey:(NSString *)key value:(nullable NSString *)value;
		[Export("setPreferenceForKey:value:")]
		void SetPreferenceForKey(string key, [NullAllowed] string value);
	}

	//@protocol AKFAccountPreferencesDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	partial interface AKFAccountPreferencesDelegate 
	{
		//- (void)accountPreferences:(AKFAccountPreferences *)accountPreferences didDeletePreferenceForKey:(NSString *)key error:(nullable NSError *)error;
		[Export("accountPreferences:didDeletePreferenceForKey:error:")]
		void DidDeletePreferenceForKey(AKFAccountPreferences accountPreferences, string key, [NullAllowed] NSError error);

		//- (void)accountPreferences:(AKFAccountPreferences *)accountPreferences didLoadPreferences:(nullable NSDictionary<NSString *, NSString *> *)preferences error:(nullable NSError *)error;
		[Export("accountPreferences:didLoadPreferences:error:")]
		void didLoadPreferences(AKFAccountPreferences accountPreferences, NSDictionary preferences, [NullAllowed] NSError error);

		//- (void)accountPreferences:(AKFAccountPreferences *)accountPreferences didLoadPreferenceForKey:(NSString *)key value:(nullable NSString *)value error:(nullable NSError *)error;
		[Export("accountPreferences:DidLoadPreferenceForKey:value:error:")]
		void DidLoadPreferenceForKey(AKFAccountPreferences accountPreferences, string key, [NullAllowed] string value, [NullAllowed] NSError error);

		//- (void)accountPreferences:(AKFAccountPreferences *)accountPreferences didSetPreferenceForKey:(NSString *)key value:(NSString *)value error:(nullable NSError *)error;
		[Export("accountPreferences:didSetPreferenceForKey:value:error:")]
		void DidSetPreferenceForKey(AKFAccountPreferences accountPreferences, string key, [NullAllowed] string value, [NullAllowed] NSError error);
	}

	//@protocol AKFConfiguring
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	partial interface AKFConfiguring 
	{
		//@property (nonatomic, copy) NSArray<NSString *> *blacklistedCountryCodes;
		[Abstract, Export("blacklistedCountryCodes", ArgumentSemantic.Copy)]
		string[] BlacklistedCountryCodes { get; set; }

		//@property (nonatomic, copy) NSString *defaultCountryCode;
		[Abstract, Export("defaultCountryCode", ArgumentSemantic.Copy)]
		string DefaultCountryCode { get; set; }

		//@property (nonatomic) BOOL enableSendToFacebook;
		[Abstract, Export("enableSendToFacebook")]
		bool EnableSendToFacebook { get; set; }

		//@property (nonatomic, copy) NSArray<NSString *> *whitelistedCountryCodes;
		[Abstract, Export("whitelistedCountryCodes", ArgumentSemantic.Copy)]
		string[] WhitelistedCountryCodes { get; set; }
	}

	//@interface AKFPhoneNumber : NSObject <NSCopying, NSSecureCoding>
	[BaseType(typeof(NSObject))]
	partial interface AKFPhoneNumber : INSCopying, INSSecureCoding
	{
		//- (instancetype)initWithCountryCode:(NSString *)countryCode phoneNumber:(NSString *)phoneNumber NS_DESIGNATED_INITIALIZER;
		[Export("initWithCountryCode:phoneNumber:")]
		IntPtr Constructor(string countryCode, string phoneNumber);

		//- (instancetype)initWithCountryCode:(NSString *)countryCode countryISO:(NSString *)iso phoneNumber:(NSString *)phoneNumber;
		[Export("initWithCountryCode:countryISO:phoneNumber:")]
		IntPtr Constructor(string countryCode, string iso, string phoneNumber);

		//@property (nonatomic, copy, readonly) NSString *countryCode;
		[Export("countryCode", ArgumentSemantic.Copy)]
		string CountryCode { get; }

		//@property (nonatomic, copy, readonly) NSString *countryISO;
		[Export("countryISO", ArgumentSemantic.Copy)]
		string CountryIso { get; }

		//@property (nonatomic, copy, readonly) NSString *phoneNumber;
		[Export("phoneNumber", ArgumentSemantic.Copy)]
		string PhoneNumber { get; }

		//- (BOOL)isEqualToPhoneNumber:(AKFPhoneNumber *)phoneNumber;
		[Export("isEqualToPhoneNumber:")]
		bool IsEqualToPhoneNumber(AKFPhoneNumber phoneNumber);

		//- (NSString *)stringRepresentation;
		[Export("stringRepresentation")]
		string stringRepresentation();
	}

	//@interface AKFSettings : NSObject
	[BaseType(typeof(NSObject))]
	partial interface AKFSettings
	{
		//+ (NSString *)clientToken;
		//+ (void)setClientToken:(NSString *)clientToken;
		[Static, Export("clientToken")]
		string ClientToken { get; [Bind("setClientToken:")] set; }
	}

	//@interface AKFSkinManager : NSObject <AKFUIManager>
	[BaseType(typeof(NSObject))]
	partial interface AKFSkinManager : AKFUIManager
	{

		//- (instancetype)initWithSkinType:(AKFSkinType)skinType primaryColor:(nullable UIColor *)primaryColor backgroundImage:(nullable UIImage *)backgroundImage backgroundTint:(AKFBackgroundTint)backgroundTint tintIntensity:(CGFloat)tintIntensity
		[Export("initWithSkinType:primaryColor:backgroundImage:backgroundTint:tintIntensity:")]
		IntPtr Constructor(AKFSkinType skinType, [NullAllowed] UIColor primaryColor, [NullAllowed] UIImage backgroundImage, AKFBackgroundTint backgroundTint, float tintIntensity);

		//- (instancetype)initWithSkinType:(AKFSkinType)skinType primaryColor:(nullable UIColor *)primaryColor;
		[Export("initWithSkinType:primaryColor:")]
		IntPtr Constructor(AKFSkinType skinType, [NullAllowed] UIColor primaryColor);
		//- (instancetype)initWithSkinType:(AKFSkinType)skinType;
		[Export("initWithSkinType:")]
		IntPtr Constructor(AKFSkinType skinType);

		//@property (nonatomic, assign, readonly) AKFSkinType skinType;
		[Export("skinType", ArgumentSemantic.Assign)]
		AKFSkinType SkinType { get; }
		//@property (null_resettable, nonatomic, copy, readonly) UIColor *primaryColor;
		[Export("primaryColor", ArgumentSemantic.Copy)]
		UIColor PrimaryColor { get; }
		//@property (nullable, nonatomic, copy, readonly) UIImage *backgroundImage;
		[Export("backgroundImage", ArgumentSemantic.Copy)]
		UIImage BackgroundImage { get; }
		//@property (nonatomic, assign, readonly) AKFBackgroundTint backgroundTint;
		[Export("BackgroundTint", ArgumentSemantic.Assign)]
		AKFBackgroundTint BackgroundTint { get; }
		//@property (nonatomic, assign, readonly) CGFloat tintIntensity;
		[Export("tintIntensity", ArgumentSemantic.Assign)]
		float TintIntensity { get; }
	}

	//@interface AKFTheme : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	partial interface AKFTheme : INSCopying
	{

		//+ (instancetype)defaultTheme;
		[Static, Export("defaultTheme")]
		AKFTheme DefaultTheme { get; }

		//+ (instancetype)outlineTheme;
		[Static, Export("outlineTheme")]
		AKFTheme OutlineTheme { get; }
		
		//+ (instancetype)outlineThemeWithPrimaryColor:(UIColor *)primaryColor primaryTextColor:(UIColor *)primaryTextColor secondaryTextColor:(UIColor *)secondaryTextColor statusBarStyle:(UIStatusBarStyle)statusBarStyle;
		[Static, Export("outlineThemeWithPrimaryColor:primaryTextColor:secondaryTextColor:statusBarStyle:")]
		AKFTheme OutlineThemeWithPrimaryColor(UIColor primaryColor, UIColor primaryTextColor, UIColor secondaryTextColor, UIStatusBarStyle statusBarStyle);

		//+ (instancetype)themeWithPrimaryColor:(UIColor *)primaryColor primaryTextColor:(UIColor *)primaryTextColor secondaryColor:(UIColor *)secondaryColor secondaryTextColor:(UIColor *)secondaryTextColor statusBarStyle:(UIStatusBarStyle)statusBarStyle;
		[Static, Export("themeWithPrimaryColor:primaryTextColor:secondaryColor:secondaryTextColor:statusBarStyle:")]
		AKFTheme ThemeWithPrimaryColor(UIColor primaryColor, UIColor primaryTextColor, UIColor secondaryColor, UIColor secondaryTextColor, UIStatusBarStyle statusBarStyle);

		//@property (nonatomic, copy) UIColor *backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Copy)]
		UIColor BackgroundColor { get; set; }
		//@property (nullable, nonatomic, copy) UIImage *backgroundImage;
		[Export("backgroundImage", ArgumentSemantic.Copy)]
		UIImage BackgroundImage { get; set; }
		//@property (nonatomic, copy) UIColor *buttonBackgroundColor;
		[Export("buttonBackgroundColor", ArgumentSemantic.Copy)]
		UIColor ButtonBackgroundColor { get; set; }
		//@property (nonatomic, copy) UIColor *buttonBorderColor;
		[Export("buttonBorderColor", ArgumentSemantic.Copy)]
		UIColor ButtonBorderColor { get; set; }
		//@property (nonatomic, copy) UIColor *buttonDisabledBackgroundColor;
		[Export("buttonDisabledBackgroundColor", ArgumentSemantic.Copy)]
		UIColor ButtonDisabledBackgroundColor { get; set; }
		//@property (nonatomic, copy) UIColor *buttonDisabledBorderColor;
		[Export("buttonDisabledBorderColor", ArgumentSemantic.Copy)]
		AKFSkinType ButtonDisabledBorderColor { get; set; }
		//@property (nonatomic, copy) UIColor *buttonDisabledTextColor;
		[Export("buttonDisabledTextColor", ArgumentSemantic.Copy)]
		UIColor ButtonDisabledTextColor { get; set; }
		//@property (nonatomic, copy) UIColor *buttonHighlightedBackgroundColor;
		[Export("buttonHighlightedBackgroundColor", ArgumentSemantic.Copy)]
		UIColor ButtonHighlightedBackgroundColor { get; set; }
		//@property (nonatomic, copy) UIColor *buttonHighlightedBorderColor;
		[Export("buttonHighlightedBorderColor", ArgumentSemantic.Copy)]
		UIColor ButtonHighlightedBorderColor { get; set; }
		//@property (nonatomic, copy) UIColor *buttonHighlightedTextColor;
		[Export("buttonHighlightedTextColor", ArgumentSemantic.Copy)]
		UIColor ButtonHighlightedTextColor { get; set; }
		//@property (nonatomic, copy) UIColor *buttonTextColor;
		[Export("buttonTextColor", ArgumentSemantic.Copy)]
		UIColor ButtonTextColor { get; set; }
		//@property (nonatomic, assign) NSUInteger contentBodyLayoutWeight;
		[Export("contentBodyLayoutWeight", ArgumentSemantic.Assign)]
		int ContentBodyLayoutWeight { get; set; }
		//@property (nonatomic, assign) NSUInteger contentBottomLayoutWeight;
		[Export("contentBottomLayoutWeight", ArgumentSemantic.Assign)]
		int ContentBottomLayoutWeight { get; set; }
		//@property (nonatomic, assign) NSUInteger contentFooterLayoutWeight;
		[Export("contentFooterLayoutWeight", ArgumentSemantic.Assign)]
		int ContentFooterLayoutWeight { get; set; }
		//@property (nonatomic, assign) NSUInteger contentHeaderLayoutWeight;
		[Export("contentHeaderLayoutWeight", ArgumentSemantic.Assign)]
		int ContentHeaderLayoutWeight { get; set; }
		//@property (nonatomic, assign) CGFloat contentMarginLeft;
		[Export("contentMarginLeft", ArgumentSemantic.Assign)]
		float ContentMarginLeft { get; set; }
		//@property (nonatomic, assign) CGFloat contentMarginRight;
		[Export("contentMarginRight", ArgumentSemantic.Assign)]
		float ContentMarginRight { get; set; }
		//@property (nonatomic, assign) CGFloat contentMaxWidth;
		[Export("contentMaxWidth", ArgumentSemantic.Assign)]
		float ContentMaxWidth { get; set; }
		//@property (nonatomic, assign) CGFloat contentMinHeight;
		[Export("contentMinHeight", ArgumentSemantic.Assign)]
		float ContentMinHeight { get; set; }
		//@property (nonatomic, assign) NSUInteger contentTextLayoutWeight;
		[Export("contentTextLayoutWeight", ArgumentSemantic.Assign)]
		int contentTextLayoutWeight { get; set; }
		//@property (nonatomic, assign) NSUInteger contentTopLayoutWeight;
		[Export("contentTopLayoutWeight", ArgumentSemantic.Assign)]
		int ContentTopLayoutWeight { get; set; }
		//@property (nonatomic, copy) UIColor *headerBackgroundColor;
		[Export("headerBackgroundColor", ArgumentSemantic.Copy)]
		UIColor HeaderBackgroundColor { get; set; }
		//@property (nonatomic, strong) UIColor *headerButtonTextColor;
		[Export("headerButtonTextColor", ArgumentSemantic.Copy)]
		UIColor HeaderButtonTextColor { get; set; }
		//@property (nonatomic, copy) UIColor *headerTextColor;
		[Export("headerTextColor", ArgumentSemantic.Copy)]
		UIColor HeaderTextColor { get; set; }
		//@property (nonatomic, assign) AKFHeaderTextType headerTextType;
		[Export("headerTextType", ArgumentSemantic.Assign)]
		AKFHeaderTextType headerTextType { get; set; }
		//@property (nonatomic, copy) UIColor *iconColor;
		[Export("iconColor", ArgumentSemantic.Copy)]
		UIColor IconColor { get; set; }
		//@property (nonatomic, copy) UIColor *inputBackgroundColor;
		[Export("inputBackgroundColor", ArgumentSemantic.Copy)]
		UIColor InputBackgroundColor { get; set; }
		//@property (nonatomic, copy) UIColor *inputBorderColor;
		[Export("inputBorderColor", ArgumentSemantic.Copy)]
		UIColor InputBorderColor { get; set; }
		//@property (nonatomic, copy) UIColor *inputTextColor;
		[Export("inputTextColor", ArgumentSemantic.Copy)]
		UIColor InputTextColor { get; set; }
		//@property (nonatomic, assign) UIStatusBarStyle statusBarStyle;
		[Export("statusBarStyle", ArgumentSemantic.Copy)]
		UIStatusBarStyle StatusBarStyle { get; set; }
		//@property (nonatomic, copy) UIColor *textColor;
		[Export("textColor", ArgumentSemantic.Copy)]
		UIColor TextColor { get; set; }
		//@property (nonatomic, copy) UIColor *titleColor;
		[Export("titleColor", ArgumentSemantic.Copy)]
		UIColor TitleColor { get; set; }

		//- (BOOL)isEqualToTheme:(AKFTheme *)theme;
		[Export("isEqualToTheme:")]
		bool IsEqualToTheme(AKFTheme theme);
	}

	//@protocol AKFUIManaging <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	partial interface AKFUIManaging 
	{
		//@property (nonatomic, strong) id<AKFUIManager> uiManager;
		[Abstract, Export("uiManager", ArgumentSemantic.Strong)]
		NSObject UIManager { get; set; }

		//- (void)setAdvancedUIManager:(id<AKFAdvancedUIManager>)uiManager;
		[Abstract, Export("setAdvancedUIManager:")]
		void SetAdvancedUiManager(NSObject uiManager);

		//- (void)setTheme:(AKFTheme *)theme;
		[Abstract, Export("setTheme:")]
		void SetTheme(AKFTheme theme);	
	}

	//@protocol AKFViewController <AKFUIManaging, AKFConfiguring>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	partial interface AKFViewController : AKFUIManaging, AKFConfiguring 
	{
		//@property (nonatomic, weak) id<AKFViewControllerDelegate> delegate;
		[Abstract, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		//@property (nonatomic, assign, readonly) AKFLoginType loginType;
		[Abstract, Export("loginType", ArgumentSemantic.Assign)]
		AKFLoginType LoginType { get; set; }
	}
	
	//@protocol AKFViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	partial interface AKFViewControllerDelegate 
	{
		//- (void)viewController:(UIViewController<AKFViewController> *)viewController didCompleteLoginWithAuthorizationCode:(NSString *)code state:(NSString *)state;
		[Export("viewController:didCompleteLoginWithAuthorizationCode:state:")]
		void DidCompleteLoginWithAuthorizationCode(UIViewController viewController, string code, string state);

		//- (void)viewController:(UIViewController<AKFViewController> *)viewController didCompleteLoginWithAccessToken:(id<AKFAccessToken>)accessToken state:(NSString *)state;
		[Export("viewController:didCompleteLoginWithAccessToken:state:")]
		void DidCompleteLoginWithAccessToken(UIViewController viewController, IAKFAccessToken accessToken, string state);

		//- (void)viewController:(UIViewController<AKFViewController> *)viewController didFailWithError:(NSError *)error;
		[Export("viewController:didFailWithError:")]
		void DidFailWithError(UIViewController viewController, NSError error);

		//- (void)viewControllerDidCancel:(UIViewController<AKFViewController> *)viewController;
		[Export("viewControllerDidCancel:")]
		void DidCancel(UIViewController viewController);
	}

	// @protocol AKFActionController <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	partial interface AKFActionController 
	{
		//- (void)back;
		[Abstract, Export("back")]
		void Back();

		//- (void)cancel;
		[Abstract, Export("cancel")]
		void Cancel();
	}

	//@protocol AKFUIManager <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	partial interface AKFUIManager 
	{
		//- (nullable UIView *)actionBarViewForState:(AKFLoginFlowState)state;
		[Export("actionBarViewForState:")]
		UIView ActionBarViewForState(AKFLoginFlowState state);

		//- (nullable UIView *)bodyViewForState:(AKFLoginFlowState)state;
		[Export("bodyViewForState:")]
		UIView BodyViewForState(AKFLoginFlowState state);

		//- (AKFButtonType)buttonTypeForState:(AKFLoginFlowState)state;
		[Export("buttonTypeForState:")]
		AKFButtonType ButtonTypeForState(AKFLoginFlowState state);

		//- (nullable UIView *)footerViewForState:(AKFLoginFlowState)state;
		[Export("footerViewForState:")]
		UIView FooterViewForState(AKFLoginFlowState state);

		//- (nullable UIView *)headerViewForState:(AKFLoginFlowState)state;
		[Export("headerViewForState:")]
		UIView HeaderViewForState(AKFLoginFlowState state);

		//- (void)setActionController:(nonnull id<AKFActionController>)actionController;
		[Export("setActionController:")]
		void SetActionController(NSObject actionController);

		//- (void)setError:(nonnull NSError *)error;
		[Export("setError:")]
		void SetError(NSError error);

		//- (AKFTextPosition)textPositionForState:(AKFLoginFlowState)state;
		[Export("textPositionForState:")]
		AKFTextPosition TextPositionForState(AKFLoginFlowState state);

		//- (nullable AKFTheme *)theme;
		[Export("theme")]
		[return: NullAllowed]
		AKFTheme theme();
	}

	[BaseType(typeof(UIViewController))]
	partial interface AKFNavigationController : AKFViewController { }

	partial interface IAKFAccessToken { }
}
