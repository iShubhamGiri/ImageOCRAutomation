Feature: OCR Validation from Dynamic Page with Resx and Aliases

  Scenario: Validate OCR text from multiple invoice pages
    Given the following OCR test data
      | Alias  | URL                   | ExpectedText        |
      | OCR1   | `OCR1.Invoice_URL`    | `OCR1.Invoice_No`   |
      | OCR2   | `OCR2.Invoice_URL`    | `OCR2.Invoice_No`   |

    And I launch the browser
    And I navigates to the Invoice Page
    When I capture the invoice image on the page
    And I extract text from the captured image
    Then the extracted text should contain `OCR1.ExpectedText`

    And I navigates to the Invoice Page
    When I capture the invoice image on the page
    And I extract text from the captured image
    Then the extracted text should contain `OCR2.ExpectedText`
