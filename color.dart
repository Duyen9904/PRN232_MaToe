import 'package:flutter/material.dart';
import 'package:theme/font.dart';

final appTheme = ThemeData(
  useMaterial3: true,
  colorScheme: lightColorScheme,
  textTheme: appFont, // Assuming appFont is defined in package:theme/font.dart
  scaffoldBackgroundColor: Color(0xFFFAFAFB),
  appBarTheme: const AppBarTheme(
    backgroundColor: Color(0xFFFAFAFA), // LightSystemUiBackgroundColor
    foregroundColor: Colors.black,
    elevation: 0,
    iconTheme: IconThemeData(color: Colors.black),
    titleTextStyle: TextStyle(
      color: Colors.black,
      fontFamily: fontFamily,
      fontSize: 20.92, // Heading/SM/Medium
      height: 25.10 / 20.92,
      fontWeight: FontWeight.w500,
    ),
  ),
  dropdownMenuTheme: DropdownMenuThemeData(
    textStyle: const TextStyle(color: Colors.black),
    menuStyle: MenuStyle(
      backgroundColor: WidgetStateProperty.all(Colors.white),
      shape: WidgetStateProperty.all(
        RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(12),
        ),
      ),
    ),
    inputDecorationTheme: InputDecorationTheme(
      filled: true,
      fillColor: const Color(0xFFdedee4), // LightDropdownFillColor
      border: OutlineInputBorder(
        borderRadius: BorderRadius.circular(16),
        borderSide: BorderSide.none,
      ),
      errorBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(16),
        borderSide: const BorderSide(
          color: Color(0xFFBD0E1F),
          width: 1,
        ),
      ),
      focusedErrorBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(16),
        borderSide: const BorderSide(
          color: Color(0xFFBD0E1F),
          width: 1,
        ),
      ),
      hintStyle: const TextStyle(color: Color(0xFF595959)),
    ),
  ),
  bottomSheetTheme: BottomSheetThemeData(
    backgroundColor: Color(0xFFFAFAFA), // LightSystemUiBackgroundColor
    shape: RoundedRectangleBorder(borderRadius: BorderRadius.vertical(top: Radius.circular(16))),
  ),
  datePickerTheme: DatePickerThemeData(
    backgroundColor: Color(0xFFFAFAFA), // LightSystemUiBackgroundColor
    dayStyle: TextStyle(color: Colors.black),
    // confirmButtonStyle: ButtonStyle(
    //   backgroundColor: WidgetStateProperty.all(lightColorScheme.tertiary), // Matches your provided Dart code
    //   foregroundColor: WidgetStateProperty.all(lightColorScheme.onTertiaryFixed),
    //   shape: MaterialStateProperty.all(RoundedRectangleBorder(borderRadius: BorderRadius.circular(8))),
    // ),
  ),
  navigationBarTheme: NavigationBarThemeData(
    backgroundColor: Color(0xFFFAFAFA), // LightSystemUiBackgroundColor
    indicatorColor: Colors.amber, // Matches your provided Dart code
    labelTextStyle: WidgetStateProperty.all(TextStyle(color: Colors.black)),
  ),
  elevatedButtonTheme: ElevatedButtonThemeData(
    style: ElevatedButton.styleFrom(
      backgroundColor: lightColorScheme.tertiary, // LightTertiaryColor
      foregroundColor: Colors.white,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(8)),
    ),
  ),
  inputDecorationTheme: InputDecorationTheme( // for text field
    contentPadding: const EdgeInsets.symmetric(horizontal: 16, vertical: 14),
    border: OutlineInputBorder(
      borderRadius: BorderRadius.circular(18),
      borderSide: BorderSide.none,
    ),
    errorBorder: OutlineInputBorder(
      borderRadius: BorderRadius.circular(10),
      borderSide: const BorderSide(color: Color(0xFFBD0E1F), width: 1),
    ),
    focusedErrorBorder: OutlineInputBorder(
      borderRadius: BorderRadius.circular(10),
      borderSide: const BorderSide(color: Color(0xFFBD0E1F), width: 1),
    ),
    hintStyle: const TextStyle(color: Color(0xFF595959)),
  ),
);

final appThemeDark = ThemeData(
  useMaterial3: true,
  colorScheme: darkColorScheme,
  textTheme: appFont, // Assuming appFont is defined in package:theme/font.dart
  scaffoldBackgroundColor: Color(0xFF1d1b20),
  appBarTheme: const AppBarTheme(
    backgroundColor: Color(0xFF000000), // DarkSystemUiBackgroundColor
    elevation: 0,
    iconTheme: IconThemeData(color: Colors.white),
    titleTextStyle: TextStyle(
      color: Colors.white,
      fontFamily: fontFamily,
      fontSize: 20.92, // Heading/SM/Medium
      height: 25.10 / 20.92,
      fontWeight: FontWeight.w500,
    ),
  ),
  dropdownMenuTheme: DropdownMenuThemeData(
    textStyle: const TextStyle(color: Colors.white),
    menuStyle: MenuStyle(
      backgroundColor: WidgetStateProperty.all(Colors.black),
      shape: WidgetStateProperty.all(
        RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(12),
        ),
      ),
    ),
    inputDecorationTheme: InputDecorationTheme(
      filled: true,
      fillColor: const Color(0xFF2B2D31), // LightDropdownFillColor
      border: OutlineInputBorder(
        borderRadius: BorderRadius.circular(16),
        borderSide: BorderSide.none,
      ),
      errorBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(16),
        borderSide: const BorderSide(
          color: Color(0xFFBD0E1F),
          width: 1,
        ),
      ),
      focusedErrorBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(16),
        borderSide: const BorderSide(
          color: Color(0xFFBD0E1F),
          width: 1,
        ),
      ),
      hintStyle: const TextStyle(color: Color(0xFFC4C4C4)),
    ),
  ),
  inputDecorationTheme: InputDecorationTheme( // for text field
    filled: true,
    fillColor: const Color(0xFF2B2D31), // Light dropdown or text field background
    contentPadding: const EdgeInsets.symmetric(horizontal: 16, vertical: 14),
    border: OutlineInputBorder(
      borderRadius: BorderRadius.circular(18),
      borderSide: BorderSide.none,
    ),
    errorBorder: OutlineInputBorder(
      borderRadius: BorderRadius.circular(10),
      borderSide: const BorderSide(color: Color(0xFFBD0E1F), width: 1),
    ),
    focusedErrorBorder: OutlineInputBorder(
      borderRadius: BorderRadius.circular(10),
      borderSide: const BorderSide(color: Color(0xFFBD0E1F), width: 1),
    ),
    hintStyle: const TextStyle(color: Color(0xFF595959)),
  ),
  navigationBarTheme: NavigationBarThemeData(
    backgroundColor: Color(0xFF000000), // DarkSystemUiBackgroundColor
    indicatorColor: Colors.amber, // Matches your provided Dart code
    labelTextStyle: MaterialStateProperty.all(TextStyle(color: Colors.white)),
  ),
);
const lightColorScheme = ColorScheme(
  brightness: Brightness.light,
  primary: Color(0xFF0D0D0C), // LightPrimaryColor
  onPrimary: Color(0xFFFFFFFF), // LightOnPrimaryColor
  primaryContainer: Color(0xFFF5F5F4), // LightPrimaryContainerColor
  onPrimaryContainer: Color(0xFF0D0D0C), // LightOnPrimaryContainerColor
  secondary: Color(0xFFEFF0F0), // LightSecondaryColor
  onSecondary: Color(0xFF1B1A19), // LightOnSecondaryColor
  secondaryContainer: Color(0xFFEFF0F0), // LightSecondaryContainerColor
  onSecondaryContainer: Color(0xFF1B1A19), // LightOnSecondaryContainerColor
  tertiary: Color(0xFF4A00B9), // LightTertiaryColor
  onTertiary: Color(0xFFEFF0F0), // LightOnTertiaryColor
  tertiaryContainer: Color(0xFFEADDFF), // LightTertiaryContainerColor
  onTertiaryContainer: Color(0xFF251A00), // LightOnTertiaryContainerColor
  error: Color(0xFFBD0E1F), // LightErrorColor
  onError: Color(0xFFFFFFFF), // LightOnErrorColor
  errorContainer: Color(0xFFFFEDEB), // LightErrorContainerColor
  onErrorContainer: Color(0xFF930012), // LightOnErrorContainerColor
  surface: Color(0xFFEFF0F0), // LightSurfaceColor
  onSurface: Color(0xFF0D0D0C), // LightOnSurfaceColor
  surfaceContainerHighest: Color(0xFFEFF0F0), // Assuming same as surface since not explicitly defined
  onSurfaceVariant: Color(0xFF595959), // LightOnSurfaceVariantColor
  outline: Color(0xFF959595), // LightOutlineColor
  outlineVariant: Color(0xFFEFF0F0), // LightOutlineVariantColor
  inverseSurface: Color(0xFF2C2B2B), // LightInverseSurfaceColor
  onInverseSurface: Color(0xFFFFFFFF), // LightOnInverseSurfaceColor
  inversePrimary: Color(0xFF9095A0), // LightInversePrimaryColor
);

const darkColorScheme = ColorScheme(
  brightness: Brightness.dark,
  primary: Color(0xFFFAFAFA), // DarkPrimaryColor
  onPrimary: Color(0xFF0D0D0C), // DarkOnPrimaryColor
  primaryContainer: Color(0xFF1B1A19), // DarkPrimaryContainerColor
  onPrimaryContainer: Color(0xFFF5F5F4), // DarkOnPrimaryContainerColor
  secondary: Color(0xFF1B1A19), // DarkSecondaryColor
  onSecondary: Color(0xFFFFFFFF), // DarkOnSecondaryColor
  secondaryContainer: Color(0xFF2C2B2B), // DarkSecondaryContainerColor
  onSecondaryContainer: Color(0xFFFFFFFF), // DarkOnSecondaryContainerColor
  tertiary: Color(0xFF4A00B9), // DarkTertiaryColor
  onTertiary: Color(0xFFEFF0F0), // DarkOnTertiaryColor
  tertiaryContainer: Color(0xFF251A00), // DarkTertiaryContainerColor
  onTertiaryContainer: Color(0xffdedee4), // DarkOnTertiaryContainerColor
  error: Color(0xFFE13034), // DarkErrorColor
  onError: Color(0xFF000000), // DarkOnErrorColor
  errorContainer: Color(0xFF410004), // DarkErrorContainerColor
  onErrorContainer: Color(0xFFFFFFFF), // DarkOnErrorContainerColor
  surface: Color(0xFF0D0D0C), // DarkSurfaceColor
  onSurface: Color(0xFFEFF0F0), // DarkOnSurfaceColor
  surfaceContainerHighest: Color(0xFF0D0D0C), // Assuming same as surface since not explicitly defined
  onSurfaceVariant: Color(0xFFC4C4C4), // DarkOnSurfaceVariantColor
  outline: Color(0xFF7C7C7C), // DarkOutlineColor
  outlineVariant: Color(0xFF2C2B2B), // DarkOutlineVariantColor
  inverseSurface: Color(0xFFFFFFFF), // DarkInverseSurfaceColor
  onInverseSurface: Color(0xFF0D0D0C), // DarkOnInverseSurfaceColor
  inversePrimary: Color(0xFF0D0D0C), // DarkInversePrimaryColor
);

extension ColorSchemeExtension on ColorScheme {
  Color get blueUltraLight => brightness == Brightness.light ? Color(0xFFF0F6FF) :  Color(0xFF0A1A2F);
  Color get greySoft => brightness == Brightness.light ? Color(0xFFdedee4) : Color(0xFF2B2D31);
  Color get greyLight => brightness == Brightness.light ? Colors.grey.shade200 : Color(0xFF7C7C7C);
  Color get darkGreyShade200 => brightness == Brightness.light ? Colors.grey.shade200 : Color(0xFF151414);
  Color get lightGreyShade300 => brightness == Brightness.light ? Colors.grey.shade300 : Color(0xFFC4C4C4);
  Color get lightTertiaryColor => brightness == Brightness.light ? Color(0xFFEAE4FB) : Color(0xFF5E3B91);
  Color get darkTertiaryColor => brightness == Brightness.light ? Color(0xFF6A5AE0) : Color(0xFF4A00B9);
  Color get neutralTertiary => brightness == Brightness.light ? Color(0xFF6A5AE0) : Color(0xFFe8e5fa);
  Color get blackGrey => brightness == Brightness.light ? Color(0xFF000000) : Color(0xFFFAFAFA);
  Color get greyGrey => brightness == Brightness.light ? Color(0xFF595959) : Color(0xFFFAFAFA);
  Color get darkGreyGrey => brightness == Brightness.light ? Color(0xFF595959) : Color(0xFFFAFAFA);
  Color get whiteGrey => brightness == Brightness.light ? Color(0xFFFFFFFF) : Color(0xFF2B2D31);
  Color get whiteWhite => brightness == Brightness.light ? Color(0xFFFFFFFF) : Color(0xFFFAFAFA);
  Color get lightBackground => brightness == Brightness.light ? Color(0xFFEAE4FB) : Color(0xFF342D4F);
  Color get softAccent => brightness == Brightness.light ? Color(0xFFFFC42E) : Color(0xFFFFD56A);
  Color get subtleGray => brightness == Brightness.light ? Color(0xFFF1F1F4) : Color(0xFF2A2A30);
  Color get strongText => brightness == Brightness.light ? Color(0xFF2E2E3A) : Color(0xFFD8D8E0);
  Color get whitePurple => brightness == Brightness.light ? Color(0xFFF4F4F8) : Color(0xFF1E1E2D);
  Color get redOrange => brightness == Brightness.light ? Color(0xFFf74231) : Color(0xff710f04);
  Color get yellowOrange => brightness == Brightness.light ? Color(0xFFFFEAD5) : Color(0xff121212);
}