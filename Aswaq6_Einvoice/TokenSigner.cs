using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Aswaq6_Einvoice
{
    class TokenSigner
    {

        private readonly string DllLibPath = "eps2003csp11.dll";
        public bool IsTokenPlagin()
        {
            Pkcs11InteropFactories interopFactories = new Pkcs11InteropFactories();
            using (IPkcs11Library ipkcs11Library = interopFactories.Pkcs11LibraryFactory.LoadPkcs11Library(interopFactories, this.DllLibPath, (AppType)0))
            {
                if (Enumerable.FirstOrDefault<ISlot>((IEnumerable<ISlot>)ipkcs11Library.GetSlotList((SlotsType)0)) != null)
                {
                    db.log_error("token is install successfully....Read " +db.Certfication);
                    return true;
                }
                else
                {
                    db.log_error("Token is not detect");
                    return false;
                }
               
            }
        }
        public static string Cades = "";
        public bool SignDocument(string File, string TokenPin, ref string cSignedDocument, ref string Error)
        {

            TokenSigner tokenSigner = new TokenSigner();
            //not found token
            //if (!File.Exists(cFile))
                if (File=="")
                {
                    Error = "no invoice detected to sign ";
                return false;
            }
            else
            //found token
            {
                //1)read Jeson File 
                string cCAdESBES = "";
                //string txt = File.ReadAllText(@"inv txt.txt") + "}";
                string txt = File + "}";


                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.FloatFormatHandling = 0;
                settings.FloatParseHandling = (FloatParseHandling)1;
                settings.DateFormatHandling = 0;
                settings.DateParseHandling = 0;
                JObject request = JsonConvert.DeserializeObject<JObject>(txt, settings);
                //2)convert txt json to Serialize
                string str_serialize = tokenSigner.Serialize(request);
                //Logger logger = Program.logger;
                string[] strArray = new string[1];

                string str = string.Format(str_serialize, Array.Empty<object>());
                strArray[0] = str;
                if (Extensions.Value<string>((IEnumerable<JToken>)request["documentTypeVersion"]) == "0.9")
                    cCAdESBES = "sign 0.9";
                else if (!tokenSigner.SignWithCMS(str_serialize, TokenPin, ref cCAdESBES, ref Error))
                    return false;
                Cades = cCAdESBES;
               // db.log_error("cCAdESBES:----"+cCAdESBES);
                return true;
            }
        }
        private byte[] HashBytes(byte[] input)
        {
            using (SHA256 shA256 = SHA256.Create())
                return shA256.ComputeHash(input);
        }
        private bool SignWithCMS(string serializedJson, string TokenPin, ref string cCAdESBES, ref string Error)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(serializedJson);
                Pkcs11InteropFactories interopFactories = new Pkcs11InteropFactories();
                using (IPkcs11Library ipkcs11Library = interopFactories.Pkcs11LibraryFactory.LoadPkcs11Library(interopFactories, this.DllLibPath, (AppType)0))

                {
                    ISlot islot = Enumerable.FirstOrDefault<ISlot>((IEnumerable<ISlot>)ipkcs11Library.GetSlotList((SlotsType)0));
                    if (islot == null)
                    {
                        Error = "Token is not detected or token driver is not installed! (slot)";
                        return false;
                    }
                    else
                    {
                        islot.GetTokenInfo();
                        islot.GetSlotInfo();
                        using (ISession isession = islot.OpenSession((SessionType)1))
                        {
                            isession.Login((CKU)1, Encoding.UTF8.GetBytes(TokenPin));
                        
                       


                            list1.Add(iobjectAttribute3);
                            List<IObjectAttribute> list2 = list1;
                            if (Enumerable.FirstOrDefault<IObjectHandle>((IEnumerable<IObjectHandle>)isession.FindAllObjects(list2)) == null)
                            {
                                Error = "Certificate was not found";
                                db.log_error(Error);
                                return false;
                            }
                            else
                            {
                                X509Store x509Store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                                X509Certificate2Collection certificate2Collection = x509Store.Certificates.Find(X509FindType.FindByIssuerName, db.Certfication, false);

                                if (certificate2Collection.Count == 0)
                                {
                                    Error = "Certificate was not found like Egypt Trust Sealing CA or some thing like that ......السيرتفيكشن مش موجوده او مش عارف يشوفها";
                                    db.log_error(Error);
                                    return false;
                                }
                                else
                                {
                                    X509Certificate2 certificate = certificate2Collection[0];
                                    x509Store.Close();
                                    SignedCms signedCms = new SignedCms(new ContentInfo(new Oid("1.2.840.113549.1.7.5"), bytes), true);
                                    EssCertIDv2 essCertIdv2_1 = new EssCertIDv2(new Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier(new DerObjectIdentifier("1.2.840.113549.1.9.16.2.47")), this.HashBytes(certificate.RawData));

                                    EssCertIDv2[] essCertIdv2Array = new EssCertIDv2[1];
                                    int index = 0;
                                    EssCertIDv2 essCertIdv2_2 = essCertIdv2_1;
                                    essCertIdv2Array[index] = essCertIdv2_2;
                                    SigningCertificateV2 signingCertificateV2 = new SigningCertificateV2(essCertIdv2Array);
                                    signedCms.ComputeSignature(new CmsSigner(certificate)
                                    {
                                        DigestAlgorithm = new Oid("2.16.840.1.101.3.4.2.1"),
                                        SignedAttributes = {
                    (AsnEncodedData) new Pkcs9SigningTime(DateTime.UtcNow),
                    new AsnEncodedData(new Oid("1.2.840.113549.1.9.16.2.47"), ((Asn1Encodable) signingCertificateV2).GetEncoded())
                  }
                                    });
                                    byte[] inArray = signedCms.Encode();
                                    cCAdESBES = Convert.ToBase64String(inArray);
                                    return true;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Error=ex.Message;
                return false;


            }
        }
        private string Serialize(JObject request)
        {
            return this.SerializeToken((JToken)request);
        }
        private string SerializeToken(JToken request)
        {
            string str1 = "";
            if (request.Parent == null)
                this.SerializeToken(request.First);
            else if (request.Type == JTokenType.Property)
            {
                string str2 = ((JProperty)request).Name.ToUpper();
                str1 = str1 + "\"" + str2 + "\"";
                foreach (JToken request1 in (IEnumerable<JToken>)request)
                {
                    if (request1.Type == JTokenType.Object)
                        str1 = str1 + this.SerializeToken(request1);
                    if (request1.Type == JTokenType.Boolean || request1.Type == JTokenType.Integer || request1.Type == JTokenType.Float || request1.Type == JTokenType.Date)
                        str1 = str1 + "\"" + Extensions.Value<string>((IEnumerable<JToken>)request1) + "\"";
                    if (request1.Type == JTokenType.String)
                        str1 = str1 + JsonConvert.ToString(Extensions.Value<string>((IEnumerable<JToken>)request1));
                    if (request1.Type == JTokenType.Array)
                    {
                        foreach (JToken request2 in request1.Children())
                        {
                            str1 = str1 + "\"" + ((JProperty)request).Name.ToUpper() + "\"";
                            str1 = str1 + this.SerializeToken(request2);
                        }
                    }
                }
            }
            if (request.Type == JTokenType.Object)
            {
                foreach (JToken request1 in request.Children())
                {
                    if (request1.Type == JTokenType.Object || request1.Type == JTokenType.Property)
                        str1 = str1 + this.SerializeToken(request1);
                }
            }
            return str1;
        }
     

    }
}
