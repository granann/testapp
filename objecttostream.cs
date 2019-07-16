void Main()
{
    LoginData obj = new LoginData
    {
        Username = "foo",
        Password = "Bar"
    };

    byte[] objBytes = Encoding.UTF8.GetBytes(obj.ToString());

//    obj.OSVersion = deviceInformation.OperatingSystem;
//    obj.DeviceModel = deviceInformation.FriendlyName;
    string URI = "https://XXXXXXXXX.azure-mobile.net/user/logsuserin";
    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(URI, UriKind.RelativeOrAbsolute));
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    request.Headers["applicationKey"] = "UFakeKkrayuAeVnoVAcjY54545455544";
    request.ContentLength = objBytes.Length;

    using (Stream stream = request.GetRequestStream())
    {
        stream.Write(objBytes, 0, objBytes.Length);
    }

    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    using (Stream stream = response.GetResponseStream())
    using (StreamReader reader = new StreamReader(stream))
    {
        Console.WriteLine(reader.ReadToEnd());
    }

}


protected void Button1_Click(object sender, EventArgs e)
{
    UserInputParameters stdObj = new UserInputParameters
    {
        AssociateRefId = "323",
        CpecialLoginId = "a@gmail.com",
        PartnerId = "aaaa",
        FirstName = "aaaa",
        LastName = "bbbb",
        Comments = "dsada",
        CreatedDate = "2013-02-25 15:25:47.077",
        Token = "asdadsadasd"
    };

    string url = "http://localhost:13384/LinkService.svc/TokenInsertion";

    try
    {
        ASCIIEncoding encoding = new ASCIIEncoding();
        System.Net.WebRequest webReq = System.Net.WebRequest.Create(url);
        webReq.Method = "POST";
        webReq.ContentType = "application/json; charset=utf-8";
        DataContractJsonSerializer ser = new DataContractJsonSerializer(stdObj.GetType());
        StreamWriter writer = new StreamWriter(webReq.GetRequestStream());
        writer.Close();
        webReq.Headers.Add("URL", "http://localhost:13381/IntegrationCheck/Default.aspx");
        System.Net.WebResponse webResp = webReq.GetResponse();
        System.IO.StreamReader sr = new System.IO.StreamReader(webResp.GetResponseStream());
        string s = sr.ReadToEnd().Trim();
    }
    catch (Exception ex)
    {
    }
}
