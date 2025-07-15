📄 ImageOCRAutomation
An end-to-end automation testing framework using Selenium + SpecFlow + MSTest for validating OCR (Optical Character Recognition) results from images using Tesseract OCR, supporting .resx-based test data, dynamic alias resolution, and multi-language image reading (including Hindi).

📦 Project Structure
vbnet
Copy
Edit
ImageOCRAutomation/
│
├── Features/
│   └── OCRValidation.feature
│
├── Steps/
│   └── OCRSteps.cs
│
├── Models/
│   └── OCRModel.cs
│
├── Utilities/
│   ├── ConfigReader.cs
│   ├── ContextManager.cs
│   ├── DriverFactory.cs
│   ├── OCRHelper.cs
│   ├── ResxDataLoader.cs
│   └── ScreenshotHelper.cs
│
├── Resources/
│   └── TestData.resx
│
├── Hooks/
│   └── Hooks.cs
│
├── Screenshots/
│   └── (Auto-generated on failures)
│
├── App.config
├── ImageOCRAutomation.csproj
├── .gitignore
└── README.md
🚀 Features
✅ Tesseract OCR integration for image text extraction.

✅ Dynamic alias-based test data from .resx (no hardcoding).

✅ Page navigation and test data control via aliases like OCR1, OCR2.

✅ Screenshot capture on failure.

✅ Hindi and multi-language OCR support.

✅ SpecFlow + MSTest-based structured testing.

✅ Clean page-independent Gherkin scenarios.

🔧 Prerequisites
.NET 6 or 7 SDK

Tesseract OCR binaries (tessdata)

Chrome browser and ChromeDriver

Visual Studio 2022 or Rider
