# 📸 ImageOCRAutomation

A real-time Selenium automation project in C# that integrates **Tesseract OCR** to extract and validate text from images on dynamic web pages. Built with **SpecFlow + MSTest** using `.resx`-based dynamic test data and alias mapping.

---

## 🚀 Features

- 🔍 Tesseract OCR image text extraction (supports multi-language like Hindi)
- 🧪 SpecFlow BDD with MSTest
- 🧾 Dynamic test data from `.resx` with alias-based referencing (`OCR1.Invoice_URL`)
- 📷 Screenshots captured and stored on validation failure
- 🌐 Selenium WebDriver browser automation
- 📁 Organized with proper Hooks, Utilities, Models, Steps, and Config

---

## 🛠️ Tech Stack

- C# (.NET)
- Selenium WebDriver
- SpecFlow + MSTest
- Tesseract OCR (via Tesseract.dll)
- Resource-based test data (.resx)
- App.config for screenshot path

---

## 📂 Folder Structure

ImageOCRAutomation/
│
├── Features/
│ └── OcrValidation.feature
│
├── Steps/
│ └── OCRSteps.cs
│
├── Models/
│ └── OCRModel.cs
│
├── Utilities/
│ ├── OCRHelper.cs
│ ├── ResxDataLoader.cs
│ ├── ContextManager.cs
│ ├── ScreenshotHelper.cs
│ └── ConfigReader.cs
│
├── Hooks/
│ └── Hooks.cs
│
├── Resources/
│ └── TestData.resx
│
├── App.config
├── ImageOCRAutomation.csproj
├── .gitignore
└── README.md
