

using GemBox.Document;
using GemBox.Document.Tables;
using GemBox.Pdf;
using GemBox.Pdf.Content;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PdfSharp.Pdf;
using sharpPDF;
using sharpPDF.Enumerators;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
/*sing static Org.BouncyCastle.Math.Primes;*/

namespace BackEndApi.Brain
{
    public class CreationPdf
    {


        // SINGLETON
        private static CreationPdf instance;

        public static CreationPdf Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CreationPdf();
                }
                return instance;
            }
        }

        public void CreatePage()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            var document = new DocumentModel();
            document.Sections.Add(new Section(document, new Paragraph(document, "Hello world!")));

            var section = new Section(document, new Paragraph(document, "Hello world!"));
            document.Sections.Add(section);

            // Foto
            var picture = new Picture(document, @"D:\Repo\FrontEndApi\src\assets\file.png");
            picture.Layout = Layout.Inline(new Size(100, 100));
            section.Blocks.Add(new Paragraph(document, picture));

            //Tabella
            var table = new Table(document, 3, 5);
            table.TableFormat.Borders.SetBorders(MultipleBorderTypes.All, BorderStyle.Dashed, Color.Blue, 1);
            table.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
            section.Blocks.Add(table);


            document.Sections.Add(
    new Section(document,
        new Paragraph(document,
            new Run(document, "This is"),
            new SpecialCharacter(document, SpecialCharacterType.LineBreak),
            new Run(document, "\xFC" + "\xF0" + "\x15") { CharacterFormat = { FontName = "Wingdings", Size = 15 } }),
        new Paragraph(document, "This is")));

            // Salvo documento
            document.Save("Document.pdf");

        }


        public void CreatePageFree()
        {

            //pdfDocument myDoc = new pdfDocument("TUTORIAL", "ME");
            pdfDocument myDoc = new pdfDocument("Sample Application", "Me", true);
            //pdfPage myPage = myDoc.addPage(100, 100);
            ///*Use the predefined Colors*/
            //myPage.addText("Hello World!", 70, 140, predefinedFont.csHelvetica, 10, new pdfColor(predefinedColor.csCyan));
            ///*Use the RGB Colors*/
            //myPage.addText("Hello World!", 70, 100, predefinedFont.csHelvetica, 10, new pdfColor(112, 27, 184));
            ///*Use the Hex Colors*/
            //myPage.addText("Hello World!", 70, 60, predefinedFont.csHelvetica, 10, new pdfColor("B81C74"));
            //myDoc.createPDF(@"D:\Desktop\Output\test.pdf");
            //myPage = null;
            //myDoc = null;


            //pdfPage myPage = myDoc.addPage();
            ///*Use the directly predefined Colors[Deprecated]*/
            //myPage.addText("Hello World!", 70, 140, predefinedFont.csHelvetica, 10, predefinedColor.csCyan);
            //myDoc.createPDF(@"D:\Desktop\Output\test.pdf");
            //myPage = null;
            //myDoc = null;


            //pdfPage myPage = myDoc.addPage();
            //myPage.addText("Hello World!", 200, 450, predefinedFont.csHelvetica, 20);
            //myDoc.createPDF(@"D:\Desktop\Output\test.pdf");
            //myPage = null;
            //myDoc = null;


            /*Creation of the first page*/
            pdfPage myFirstPage = myDoc.addPage();
            myFirstPage.addText("Hello World!", 70, 140, predefinedFont.csHelvetica, 10, new pdfColor(predefinedColor.csCyan));
            /*Use the RGB Colors*/
            myFirstPage.addText("Hello World!", 70, 100, predefinedFont.csHelvetica, 10, new pdfColor(112, 27, 184));
            /*Use the Hex Colors*/
            myFirstPage.addText("Hello World!", 70, 60, predefinedFont.csHelvetica, 10, new pdfColor("B81C74"));
            /*Draw the line on the first page*/
            myFirstPage.drawLine(100, 100, 200, 200, predefinedLineStyle.csNormal, new pdfColor(predefinedColor.csBlue), 10);
            /*Creation of the second page*/
            pdfPage mySecondPage = myDoc.addPage();
            mySecondPage.addText("Hello World!", 70, 140, predefinedFont.csHelvetica, 10, new pdfColor(predefinedColor.csCyan));
            /*Use the RGB Colors*/
            mySecondPage.addText("Hello World!", 70, 100, predefinedFont.csHelvetica, 10, new pdfColor(112, 27, 184));
            /*Use the Hex Colors*/
            mySecondPage.addText("Hello World!", 70, 60, predefinedFont.csHelvetica, 10, new pdfColor("B81C74"));
            /*Draw the rectangle on the second page*/
            mySecondPage.drawRectangle(100, 100, 300, 200, new pdfColor(predefinedColor.csBlue), new pdfColor(predefinedColor.csYellow), 1, predefinedLineStyle.csNormal);
            /*Creation of the third page*/
            pdfPage myThirdPage = myDoc.addPage();
            myThirdPage.addText("Hello World!", 70, 140, predefinedFont.csHelvetica, 10, new pdfColor(predefinedColor.csCyan));
            /*Use the RGB Colors*/
            myThirdPage.addText("Hello World!", 70, 100, predefinedFont.csHelvetica, 10, new pdfColor(112, 27, 184));
            /*Use the Hex Colors*/
            myThirdPage.addText("Hello World!", 70, 60, predefinedFont.csHelvetica, 10, new pdfColor("B81C74"));
            /*Draw the circle on the third page-*/
            myThirdPage.drawCircle(200, 200, 50, new pdfColor(predefinedColor.csBlue), new pdfColor(predefinedColor.csYellow), predefinedLineStyle.csNormal, 1);
            myDoc.createPDF(@"D:\Desktop\Output\test.pdf");
            myFirstPage = null;
            mySecondPage = null;
            myThirdPage = null;
            myDoc = null;


            // https://sharppdf.sourceforge.net/Tutorials.html

        }
    }
    
}
