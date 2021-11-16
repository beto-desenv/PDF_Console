using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace PDF_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            string caminho = @"D:\pdf\" + "relatório.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph
            {
                Font = new Font(Font.COURIER, 40),
                Alignment = Element.ALIGN_CENTER
            };
            titulo.Add("teste\n\n");
            doc.Add(titulo);

            Paragraph paragrafo = new Paragraph("", new Font(Font.NORMAL, 12));
            string conteudo = "texto de teste para geração do pdf";
            paragrafo.Add(conteudo);
            doc.Add(paragrafo);

            PdfPTable table = new PdfPTable(3);
            for (int i = 1; i <= 10; i++)
            {
                table.AddCell("Linha " + i + ", Coluna 1");
                table.AddCell("Linha " + i + ", Coluna 2");
                table.AddCell("Linha " + i + ", Coluna 3");
            }
            doc.Add(table);

            string simg = "https://upload.wikimedia.org/wikipedia/commons/a/a5/%C3%82nima_Educa%C3%A7%C3%A3o.png";
            Image img = Image.GetInstance(simg);
            img.ScaleAbsolute(100, 130);
            img.SetAbsolutePosition(10, 30);

            doc.Add(img);

            doc.Close();
            System.Diagnostics.Process.Start(caminho);
        }
    }
}
