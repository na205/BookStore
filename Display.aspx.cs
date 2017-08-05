using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using BookStore;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;

public class BookData
{
    public string BookLink { get; set; }
    public string BookName { get; set; }
    public string BookImage { get; set; }
}
public partial class Display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string filename = "defaultBook.jpg";
        WebClient r = new WebClient();
        string content = r.DownloadString("https://github.com/na205/Unscrambler_iOS2/tree/master/Unscrambler");
        List<BookData> files = new List<BookData>();
        foreach (Match m in Regex.Matches(content, @"(na205/Unscrambler_iOS2/blob/master/Unscrambler.*?..m)"))
        {
            BookData bd = new BookData();
            bd.BookImage = filename;
            bd.BookLink = "https://github.com/"+m.Value;
            bd.BookName = m.Value;
            files.Add(bd);
        }
        gdImage.DataSource = files;
        gdImage.DataBind();
    }
    protected void bttnpdf_Click(object sender, EventArgs e)
    {
        string FilePath = Server.MapPath("https://github.com/na205/C-and-Cpp-Programs/blob/master/Extra%20material/Dynamic%20Programming/DynamicProgramming.pdf");
        WebClient User = new WebClient();
        Byte[] FileBuffer = User.DownloadData(FilePath);
        if (FileBuffer != null)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", FileBuffer.Length.ToString());
            Response.BinaryWrite(FileBuffer);
        }
    }
    protected void View(object sender, EventArgs e)
    {
        string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"500px\" height=\"300px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        //ltEmbed.Text = string.Format(embed, ResolveUrl("~/Images/fsf_gg.pdf"));
    }
}