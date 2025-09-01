using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;

using System.Text;
using System.Threading.Tasks;

namespace Aswaq6_Einvoice
{
    class Einvoice
    {
        static public String Generat_JSON(

        ref string Json,
        ref  DataTable dt,
        ref string documentType,
        ref string receiver_country,
        ref string subType_rat_vcs,
        ref string subType_vcs,
        ref bool exemption_vat,
     //   ref Decimal amountSold,
        ref Decimal currencyExchangeRate,
        ref bool FoundcurrencySold,
        ref string currencySold,
        ref string dateTimeIssued,
         ref string dateValidity,
         ref string receiver_regionCity,
         ref string receiver_governate,
         ref string receiver_street,
         ref string receiver_buildingNumber,
         ref string receiver_type,
         ref string receiver_id,
         ref string receiver_name,
         ref string no_invoice_internalID,
         ref string purchaseOrderReference,
         ref string salesOrderReference,
         ref string salesOrderDescription,
         ref string proformaInvoiceNumber,
         ref bool incloud_1_vat
          )


        {
            string body_invoice = "";
            string invoice = "";
            string vtoken = "";
            if (db.pinToken!="")
            { vtoken = "1.0"; }
            else
            {
                vtoken = "0.9";
            }
            //with payment and delevry
            //    string header = "{  \n \t  \"issuer\": {\n\t    \"address\": { \n\t   \"branchID\": \"0\",  \n \t\"country\": \"EG\", \n \t\"governate\": \"" + v.txt_e_govern + "\", \n \t  \"regionCity\": \"" + v.txt_e_city + "\",  \n \t  \"street\": \"" + v.txt_e_street + "\",  \n \t \"buildingNumber\": \"" + v.txt_e_build + "\",  \n \t \"postalCode\": \"\",  \n \t\"floor\": \"10\",  \n \t \"room\": \"\", \n \t \"landmark\": \"" + v.txt_e_street + "\", \n \t \"additionalInformation\": \"" + v.txt_e_street + "\"  \n \t }, \n \t \"type\": \"B\", \n \t  \"id\": \"" + v.txt_e_rkamtgary + "\", \n \t  \"name\": \"" + v.txt_e_name_company + "\"  \n \t }, \n \t \"receiver\":\n \t { \n \t  \"address\": { \n \t  \"country\": \""+ receiver_country + "\", \n \t \"governate\": \"" + receiver_governate + "\", \n \t \"regionCity\": \"" + receiver_regionCity + "\", \n \t \"street\": \"" + receiver_street + "\", \n \t \"buildingNumber\": \"" + receiver_buildingNumber + "\", \n \t\"postalCode\": \"\",\n \t \"floor\": \"1\",\n \t\"room\": \"1\", \n \t\"landmark\": \"\", \n \t \"additionalInformation\": \"\"  \n \t }, \n \t \"type\": \"" + receiver_type + "\", \n \t \"id\": \"" + receiver_id.ToString().Trim() + "\",\n \t  \"name\": \"" + receiver_name.ToString().Trim() + "\"   \n \t}, \n \t \"documentType\": \""+ documentType + "\", \n \t  \"documentTypeVersion\": \"" + vtoken + "\", \n \t \"dateTimeIssued\":\"" + dateTimeIssued + "\",\n \t   \"taxpayerActivityCode\": \"" + v.txt_activity + "\", \n \t  \"internalID\": \"" + no_invoice_internalID + "\",\n \t  \"purchaseOrderReference\": \"" + purchaseOrderReference + "\", \n \t  \"purchaseOrderDescription\": \"purchase Order description\",\n \t   \"salesOrderReference\": \"" + salesOrderReference + "\",\n \t  \"salesOrderDescription\": \"" + salesOrderDescription + "\",\n \t  \"proformaInvoiceNumber\": \"" + proformaInvoiceNumber + "\",\n \t   \"payment\": \n \t{    \"bankName\": \"SomeValue\", \n \t\"bankAddress\": \"SomeValue\",\n \t    \"bankAccountNo\": \"SomeValue\",   \n \t\"bankAccountIBAN\": \"\",\n \t  \"swiftCode\": \"\", \n \t \"terms\":\n \t \"SomeValue\"   \n \t }, \n \t   \"delivery\":\n \t { \n \t  \"approach\": \"SomeValue\",\n \t \"packaging\": \"SomeValue\",\n \t  \"dateValidity\": \"" + dateValidity + "\",\n \t  \"exportPort\": \"SomeValue\",\n \t   \"grossWeight\": 0,\n \t   \"netWeight\": 0,\n \t  \"terms\": \"SomeValue\" \n \t},     ";
            string header = "{  \n \t  \"issuer\": {\n\t    \"address\": { \n\t   \"branchID\": \"0\",  \n \t\"country\": \"EG\", \n \t\"governate\": \"" + v.txt_e_govern + "\", \n \t  \"regionCity\": \"" + v.txt_e_city + "\",  \n \t  \"street\": \"" + v.txt_e_street + "\",  \n \t \"buildingNumber\": \"" + v.txt_e_build + "\",  \n \t \"postalCode\": \"\",  \n \t\"floor\": \"10\",  \n \t \"room\": \"\", \n \t \"landmark\": \"" + v.txt_e_street + "\", \n \t \"additionalInformation\": \"" + v.txt_e_street + "\"  \n \t }, \n \t \"type\": \"B\", \n \t  \"id\": \"" + v.txt_e_rkamtgary + "\", \n \t  \"name\": \"" + v.txt_e_name_company + "\"  \n \t }, \n \t \"receiver\":\n \t { \n \t  \"address\": { \n \t  \"country\": \"" + receiver_country + "\", \n \t \"governate\": \"" + receiver_governate + "\", \n \t \"regionCity\": \"" + receiver_regionCity + "\", \n \t \"street\": \"" + receiver_street + "\", \n \t \"buildingNumber\": \"" + receiver_buildingNumber + "\", \n \t\"postalCode\": \"\",\n \t \"floor\": \"1\",\n \t\"room\": \"1\", \n \t\"landmark\": \"\", \n \t \"additionalInformation\": \"\"  \n \t }, \n \t \"type\": \"" + receiver_type + "\", \n \t \"id\": \"" + receiver_id.ToString().Trim() + "\",\n \t  \"name\": \"" + receiver_name.ToString().Trim() + "\"   \n \t}, \n \t \"documentType\": \"" + documentType + "\", \n \t  \"documentTypeVersion\": \"" + vtoken + "\", \n \t \"dateTimeIssued\":\"" + dateTimeIssued + "\",\n \t   \"taxpayerActivityCode\": \"" + v.txt_activity + "\", \n \t  \"internalID\": \"" + no_invoice_internalID + "\",\n \t  \"purchaseOrderReference\": \"" + purchaseOrderReference + "\", \n \t  \"purchaseOrderDescription\": \"purchase Order description\",\n \t   \"salesOrderReference\": \"" + salesOrderReference + "\",\n \t  \"salesOrderDescription\": \"" + salesOrderDescription + "\",\n \t  \"proformaInvoiceNumber\": \"" + proformaInvoiceNumber + "\",   ";

            //calc Footer
            Decimal totalDiscountAmount =0;
            Decimal totalSalesAmount =0;
            Decimal netAmount =0;
            Decimal amount  =0;
            Decimal amount_add = 0;
            Decimal totalAmount =0 ;
            Decimal extraDiscountAmount=0  ;
            string footer = "";
            string tot = "";
            string subType = "";
            string rat_vcs = "";
            string taxType_add = "";
            string subType_add = "";
            string amount_sold = "";

            //add tax 1 % is active
            if (incloud_1_vat)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    totalDiscountAmount += Convert.ToDecimal(dt.Rows[i][15]);
                    totalSalesAmount += Convert.ToDecimal(dt.Rows[i][6]);
                    netAmount += Convert.ToDecimal(dt.Rows[i][10]);
                    amount += Convert.ToDecimal(dt.Rows[i][17]);
                    amount_add += Convert.ToDecimal(dt.Rows[i][33]);
                    extraDiscountAmount = Convert.ToDecimal(dt.Rows[i][20]);
                    totalAmount = netAmount + amount - amount_add - extraDiscountAmount;
                    taxType_add = dt.Rows[i][30] + "".Trim();
                    subType_add = dt.Rows[i][31] + "".Trim();


                }
                footer = ", \n \t\"totalDiscountAmount\": " + Math.Round(totalDiscountAmount,v.Round) + ", \n \t\"totalSalesAmount\": " + Math.Round(totalSalesAmount,v.Round) + ",\n \t \"netAmount\": " + Math.Round(netAmount,v.Round) + ", \n \t\"taxTotals\":[  \n \t {  \n \t   \"taxType\": \"T1\", \n \t\"amount\": " + Math.Round(amount,v.Round) + "  \n \t},{  \n \t   \"taxType\": \""+ taxType_add + "\", \n \t\"amount\": " + Math.Round(amount_add,v.Round) + "  \n \t}\n \t ],\n \t \"totalAmount\": " + Math.Round(totalAmount,v.Round) + ",\n \t \"extraDiscountAmount\": " + Math.Round(extraDiscountAmount,v.Round) + ", \n \t\"totalItemsDiscountAmount\": " + 0 + "  ";
                //footer = ", \n \t\"totalDiscountAmount\": " + Math.Round(totalDiscountAmount, v.Round) + ", \n \t\"totalSalesAmount\": " + Math.Round(totalSalesAmount, v.Round) + ",\n \t \"netAmount\": " + Math.Round(netAmount, v.Round) + ", \n \t\"taxTotals\":[  \n \t {  \n \t   \"taxType\": \"T1\", \n \t\"amount\": " + Math.Round(amount, v.Round) + "  \n \t},{  \n \t   \"taxType\": \"T4\", \n \t\"amount\": " + Math.Round(amount_add, v.Round) + "  \n \t}\n \t ],\n \t \"totalAmount\": " + Math.Round(totalAmount, v.Round) + ",\n \t \"extraDiscountAmount\": " + Math.Round(extraDiscountAmount, v.Round) + ", \n \t\"totalItemsDiscountAmount\": " + 0 + "  ";

            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    totalDiscountAmount += Convert.ToDecimal(dt.Rows[i][15]);
                    totalSalesAmount += Convert.ToDecimal(dt.Rows[i][6]);
                    netAmount += Convert.ToDecimal(dt.Rows[i][10]);
                    amount += Convert.ToDecimal(dt.Rows[i][17]);
                    extraDiscountAmount = Convert.ToDecimal(dt.Rows[i][20]);
                    totalAmount = netAmount + amount- extraDiscountAmount;
                }
                footer = ", \n \t\"totalDiscountAmount\": " + Math.Round(totalDiscountAmount, v.Round) + ", \n \t\"totalSalesAmount\": " + Math.Round(totalSalesAmount, v.Round) + ",\n \t \"netAmount\": " + Math.Round(netAmount, v.Round) + ", \n \t\"taxTotals\":[  \n \t {  \n \t   \"taxType\": \"T1\", \n \t\"amount\": " + Math.Round(amount, v.Round) + "  \n \t}\n \t ],\n \t \"totalAmount\": " + Math.Round(totalAmount, v.Round) + ",\n \t \"extraDiscountAmount\": " + Math.Round(extraDiscountAmount, v.Round) + ", \n \t\"totalItemsDiscountAmount\": " + 0 + "  ";
            }
            //body Document
            //======================================================================
            if (dt.Rows.Count == 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //add tax 1 % is active
                    if (incloud_1_vat)
                    {
                        tot = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[i][7]), v.Round))- (Math.Round(Convert.ToDecimal(dt.Rows[i][33]), v.Round)) + "" : (Math.Round(Convert.ToDecimal(dt.Rows[i][10]), v.Round))-(Math.Round(Convert.ToDecimal(dt.Rows[i][33]), v.Round)) + "";
                        subType = (!exemption_vat) ? (dt.Rows[i][18]) + "" : subType_vcs;
                        rat_vcs = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[i][19]), v.Round)) + "" : "0";
                        if (FoundcurrencySold==true)
                        {
                            amount_sold = (Math.Round(Convert.ToDecimal(dt.Rows[i][25]), v.Round)) + "";
                        }
                        else
                        {
                            amount_sold = "0";
                        }


                        body_invoice += "  { \n \t   \"description\":\"" + dt.Rows[i][0] + "\",  \n \t  \"itemType\":\"" + dt.Rows[i][1] + "\",  \n \t  \"itemCode\":\"" + dt.Rows[i][2] + "\",  \n \t  \"unitType\":\"" + dt.Rows[i][3]+"".Trim() + "\",  \n \t \"quantity\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][4]),v.Round) + ",  \n \t \"internalCode\":\"" + dt.Rows[i][5] + "\",  \n \t \"salesTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][6]),v.Round) + ",  \n \t \"total\":" +tot + ",  \n \t \"valueDifference\":0,  \n \t \"totalTaxableFees\":0,  \n \t \"netTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][10]),v.Round) + ",\n \t \"itemsDiscount\":0 , \n\t \"unitValue\": {  \n\t         \n \t \"currencySold\":\"" + currencySold.Trim() + "\",  \n \t \"amountEGP\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][13]),v.Round) + " \n\t, \"amountSold\": " + amount_sold + " \n\t, \"currencyExchangeRate\": " + Math.Round(currencyExchangeRate, v.Round) + " \n\t } ,  \n\t \"discount\": {   \n \t \"rate\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][14]),v.Round) + ",  \n \t \"amount\":" +Math.Round(Convert.ToDecimal(dt.Rows[i][15]),v.Round) + " \n\t } ,\n\t \"taxableItems\": [ \n \t{   \n \t \"taxType\":\"" + dt.Rows[i][16] + "\",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][17]),v.Round) + ",  \n \t \"subType\":\"" + subType + "\",  \n \t \"rate\":" +rat_vcs + " \n \t  },{   \n \t \"taxType\":\"" + dt.Rows[i][30] + "\",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][33]),v.Round) + ",  \n \t \"subType\":\"" + dt.Rows[i][31] + "\",  \n \t \"rate\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][32]),v.Round) + " \n \t  }\n\t ]  \n\t } ";
                    }
                    else
                    {
                        tot = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[i][7]), v.Round)) + "" : (Math.Round(Convert.ToDecimal(dt.Rows[i][10]), v.Round))+"";
                        subType = (!exemption_vat) ? (dt.Rows[i][18]) + "" : subType_vcs;
                        rat_vcs = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[i][19]), v.Round)) + "" : "0";
                        if (FoundcurrencySold == true)
                        {
                            amount_sold = (Math.Round(Convert.ToDecimal(dt.Rows[i][25]), v.Round)) + "";
                        }
                        else
                        {
                            amount_sold = "0";
                        }

                        body_invoice += "  { \n \t   \"description\":\"" + dt.Rows[i][0] + "\",  \n \t  \"itemType\":\"" + dt.Rows[i][1].ToString().Trim() + "\",  \n \t  \"itemCode\":\"" + dt.Rows[i][2].ToString().Trim() + "\",  \n \t  \"unitType\":\"" + dt.Rows[i][3].ToString().Trim() + "\",  \n \t \"quantity\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][4]), v.Round) + ",  \n \t \"internalCode\":\"" + dt.Rows[i][5].ToString().Trim() + "\",  \n \t \"salesTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][6]), v.Round) + ",  \n \t \"total\":" +tot + ",  \n \t \"valueDifference\":0,  \n \t \"totalTaxableFees\":0,  \n \t \"netTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][10]), v.Round) + ",\n \t \"itemsDiscount\":0 , \n\t \"unitValue\": {  \n\t         \n \t \"currencySold\":\"" + currencySold.Trim() + "\",  \n \t \"amountEGP\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][13]), v.Round) + " \n\t, \"amountSold\": " + amount_sold + " \n\t, \"currencyExchangeRate\": "+ Math.Round(currencyExchangeRate, v.Round) + " \n\t } ,  \n\t \"discount\": {   \n \t \"rate\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][14]), v.Round) + ",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][15]), v.Round) + " \n\t } ,\n\t \"taxableItems\": [ \n \t{   \n \t \"taxType\":\"" + dt.Rows[i][16] + "\",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][17]), v.Round) + ",  \n \t \"subType\":\"" + subType + "\",  \n \t \"rate\":" + rat_vcs + " \n \t  }\n\t ]  \n\t } ";
                    }
                }
                invoice = header + "\"invoiceLines\": [ \n \t " + body_invoice + " \n\t ] \n \t" + footer;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    //add tax 1 % is active
                    if (incloud_1_vat)
                    {
                        tot = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[i][7]), v.Round)) - (Math.Round(Convert.ToDecimal(dt.Rows[i][33]), v.Round)) + "" : (Math.Round(Convert.ToDecimal(dt.Rows[i][10]), v.Round)) - (Math.Round(Convert.ToDecimal(dt.Rows[i][33]), v.Round)) + "";
                       // tot = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[i][7]), v.Round)) - (Math.Round(Convert.ToDecimal(dt.Rows[i][33]), v.Round)) + "" : (Math.Round(Convert.ToDecimal(dt.Rows[i][10]), v.Round)) - (Math.Round(Convert.ToDecimal(dt.Rows[i][33]), v.Round)) + "";

                        rat_vcs = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[i][19]), v.Round)) + "" : "0";

                        // tot = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[i][7]), v.Round)) + "" : (Math.Round(Convert.ToDecimal(dt.Rows[i][10]), v.Round))+"";
                        subType = (!exemption_vat) ? (dt.Rows[i][18]) + "" : subType_vcs;
                        if (FoundcurrencySold == true)
                        {
                            amount_sold = (Math.Round(Convert.ToDecimal(dt.Rows[i][25]), v.Round)) + "";
                        }
                        else
                        {
                            amount_sold = "0";
                        }
                        body_invoice += "  { \n \t   \"description\":\"" + dt.Rows[i][0] + "\",  \n \t  \"itemType\":\"" + dt.Rows[i][1] + "\",  \n \t  \"itemCode\":\"" + dt.Rows[i][2] + "\",  \n \t  \"unitType\":\"" + dt.Rows[i][3]+"".Trim() + "\",  \n \t \"quantity\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][4]), v.Round) + ",  \n \t \"internalCode\":\"" + dt.Rows[i][5] + "\",  \n \t \"salesTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][6]), v.Round) + ",  \n \t \"total\":" + tot + ",  \n \t \"valueDifference\":0,  \n \t \"totalTaxableFees\":0,  \n \t \"netTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][10]), v.Round) + ",\n \t \"itemsDiscount\":0 , \n\t \"unitValue\": {  \n\t         \n \t \"currencySold\":\"" + currencySold.Trim() + "\",  \n \t \"amountEGP\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][13]), v.Round) + " \n\t, \"amountSold\": " + amount_sold + " \n\t, \"currencyExchangeRate\": " + Math.Round(currencyExchangeRate, v.Round) + " \n\t } ,  \n\t \"discount\": {   \n \t \"rate\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][14]), v.Round) + ",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][15]), v.Round) + " \n\t } ,\n\t \"taxableItems\": [ \n \t{   \n \t \"taxType\":\"" + dt.Rows[i][16] + "\",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][17]), v.Round) + ",  \n \t \"subType\":\"" + dt.Rows[i][18] + "\",  \n \t \"rate\":" + rat_vcs + " \n \t  },{   \n \t \"taxType\":\"" + dt.Rows[i][30] + "\",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][33]), v.Round) + ",  \n \t \"subType\":\"" + dt.Rows[i][31] + "\",  \n \t \"rate\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][32]), v.Round) + " \n \t  }\n\t ]  \n\t }, ";

                    }
                    else
                    {
                       // tot = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[i][7]), v.Round)) - (Math.Round(Convert.ToDecimal(dt.Rows[i][33]), v.Round)) + "" : (Math.Round(Convert.ToDecimal(dt.Rows[i][10]), v.Round)) - (Math.Round(Convert.ToDecimal(dt.Rows[i][33]), v.Round)) + "";

                        tot = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[i][7]), v.Round)) + "" : (Math.Round(Convert.ToDecimal(dt.Rows[i][10]), v.Round))+"";
                        subType = (!exemption_vat) ? (dt.Rows[i][18]) + "" : subType_vcs;
                        rat_vcs = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[i][19]), v.Round)) + "" : "0";
                        if (FoundcurrencySold == true)
                        {
                            amount_sold = (Math.Round(Convert.ToDecimal(dt.Rows[i][25]), v.Round)) + "";
                        }
                        else
                        {
                            amount_sold = "0";
                        }
                        body_invoice += "  { \n \t   \"description\":\"" + dt.Rows[i][0].ToString().Trim() + "\",  \n \t  \"itemType\":\"" + dt.Rows[i][1].ToString().Trim() + "\",  \n \t  \"itemCode\":\"" + dt.Rows[i][2].ToString().Trim() + "\",  \n \t  \"unitType\":\"" + dt.Rows[i][3].ToString().Trim() + "\",  \n \t \"quantity\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][4]), v.Round) + ",  \n \t \"internalCode\":\"" + dt.Rows[i][5] + "\",  \n \t \"salesTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][6]), v.Round) + ",  \n \t \"total\":" + tot + ",  \n \t \"valueDifference\":0,  \n \t \"totalTaxableFees\":0,  \n \t \"netTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][10]), v.Round) + ",\n \t \"itemsDiscount\":0, \n\t \"unitValue\": {  \n\t         \n \t \"currencySold\":\"" + currencySold.Trim() + "\",  \n \t \"amountEGP\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][13]), v.Round) + " \n\t, \"amountSold\":"+ amount_sold + " \n\t, \"currencyExchangeRate\": "+ Math.Round(currencyExchangeRate, v.Round) + " \n\t} ,  \n\t \"discount\": {   \n \t \"rate\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][14]), v.Round) + ",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][15]), v.Round) + " \n\t } ,\n\t \"taxableItems\": [ \n \t{   \n \t \"taxType\":\"" + dt.Rows[i][16] + "\",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[i][17]), v.Round) + ",  \n \t \"subType\":\"" + subType + "\",  \n \t \"rate\":" + rat_vcs + " \n \t  }\n\t ]  \n\t }, ";
                    }
                }
                int m = dt.Rows.Count - 1;
                //add tax 1 % is active

                if (incloud_1_vat)
                {
                    tot = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[m][7]), v.Round)) - (Math.Round(Convert.ToDecimal(dt.Rows[m][33]), v.Round)) + "" : (Math.Round(Convert.ToDecimal(dt.Rows[m][10]), v.Round)) - (Math.Round(Convert.ToDecimal(dt.Rows[m][33]), v.Round)) + "";

                    //  tot = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[m][7]), v.Round)) + "" : (Math.Round(Convert.ToDecimal(dt.Rows[m][10]), v.Round))+"";
                    subType = (!exemption_vat) ? (dt.Rows[m][18]) + "" : subType_vcs;
                        rat_vcs = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[m][19]), v.Round)) + "" : "0";
                    if (FoundcurrencySold == true)
                    {
                        amount_sold = (Math.Round(Convert.ToDecimal(dt.Rows[m][25]), v.Round)) + "";
                    }
                    else
                    {
                        amount_sold = "0";
                    }
                    body_invoice += "  { \n \t   \"description\":\"" + dt.Rows[m][0] + "\",  \n \t  \"itemType\":\"" + dt.Rows[m][1] + "\",  \n \t  \"itemCode\":\"" + dt.Rows[m][2] + "\",  \n \t  \"unitType\":\"" + dt.Rows[m][3]+"".Trim() + "\",  \n \t \"quantity\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][4]), v.Round) + ",  \n \t \"internalCode\":\"" + dt.Rows[m][5] + "\",  \n \t \"salesTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][6]), v.Round) + ",  \n \t \"total\":" + tot + ",  \n \t \"valueDifference\":0,  \n \t \"totalTaxableFees\":0,  \n \t \"netTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][10]), v.Round) + ",\n \t \"itemsDiscount\":0, \n\t \"unitValue\": {  \n\t         \n \t \"currencySold\":\"" + currencySold.Trim() + "\",  \n \t \"amountEGP\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][13]), v.Round) + " \n\t, \"amountSold\": " + amount_sold + " \n\t, \"currencyExchangeRate\": " + Math.Round(currencyExchangeRate, v.Round) + " \n\t } ,  \n\t \"discount\": {   \n \t \"rate\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][14]), v.Round) + ",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][15]), v.Round) + " \n\t } ,\n\t \"taxableItems\": [ \n \t{   \n \t \"taxType\":\"" + dt.Rows[m][16] + "\",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][17]), v.Round) + ",  \n \t \"subType\":\"" + dt.Rows[m][18] + "\",  \n \t \"rate\":" + rat_vcs + " \n \t  },{   \n \t \"taxType\":\"" + dt.Rows[m][30] + "\",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][33]), v.Round) + ",  \n \t \"subType\":\"" + dt.Rows[m][31] + "\",  \n \t \"rate\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][32]), v.Round) + " \n \t  }\n\t ]  \n\t } ";
                }
                else
                {
                  //  tot = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[m][7]), v.Round)) - (Math.Round(Convert.ToDecimal(dt.Rows[m][33]), v.Round)) + "" : (Math.Round(Convert.ToDecimal(dt.Rows[m][10]), v.Round)) - (Math.Round(Convert.ToDecimal(dt.Rows[m][33]), v.Round)) + "";

                    tot = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[m][7]), v.Round)) + "" : (Math.Round(Convert.ToDecimal(dt.Rows[m][10]), v.Round))+"";
                    subType = (!exemption_vat) ? (dt.Rows[m][18]) + "" : subType_vcs;
                    rat_vcs = (!exemption_vat) ? (Math.Round(Convert.ToDecimal(dt.Rows[m][19]), v.Round)) + "" : "0";
                    if (FoundcurrencySold == true)
                    {
                        amount_sold = (Math.Round(Convert.ToDecimal(dt.Rows[m][25]), v.Round)) + "";
                    }
                    else
                    {
                        amount_sold = "0";
                    }
                    body_invoice += "  { \n \t   \"description\":\"" + dt.Rows[m][0].ToString().Trim() + "\",  \n \t  \"itemType\":\"" + dt.Rows[m][1].ToString().Trim() + "\",  \n \t  \"itemCode\":\"" + dt.Rows[m][2].ToString().Trim() + "\",  \n \t  \"unitType\":\"" + dt.Rows[m][3].ToString().Trim() + "\",  \n \t \"quantity\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][4]), v.Round) + ",  \n \t \"internalCode\":\"" + dt.Rows[m][5].ToString().Trim() + "\",  \n \t \"salesTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][6]), v.Round) + ",  \n \t \"total\":" + tot + ",  \n \t \"valueDifference\":0,  \n \t \"totalTaxableFees\":0,  \n \t \"netTotal\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][10]), v.Round) + ",\n \t \"itemsDiscount\":0 , \n\t \"unitValue\": {  \n\t         \n \t \"currencySold\":\"" + currencySold.Trim() + "\",  \n \t \"amountEGP\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][13]), v.Round) + " \n\t, \"amountSold\": "+ amount_sold + " \n\t, \"currencyExchangeRate\": "+ Math.Round(currencyExchangeRate, v.Round) + " \n\t } ,  \n\t \"discount\": {   \n \t \"rate\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][14]), v.Round) + ",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][15]), v.Round) + " \n\t } ,\n\t \"taxableItems\": [ \n \t{   \n \t \"taxType\":\"" + dt.Rows[m][16] + "\",  \n \t \"amount\":" + Math.Round(Convert.ToDecimal(dt.Rows[m][17]), v.Round) + ",  \n \t \"subType\":\"" + subType + "\",  \n \t \"rate\":" + rat_vcs + " \n \t  }\n\t ]  \n\t } ";
                }
                invoice = header + "\"invoiceLines\": [ \n \t " + body_invoice + " \n\t ] \n \t" + footer;
            }
            //  db.log_error(invoice);
            //(Condition) ? "Value For true":" Value For False "  

            if (invoice.Contains("*") || invoice.Contains("\\") || invoice.Contains("\'") || invoice.Contains("/") || invoice.Contains("?"))
            {
                invoice = invoice.Replace("*", " ");
                invoice = invoice.Replace("\\", " ");
                invoice = invoice.Replace("\'", " ");
                invoice = invoice.Replace("/", " ");
                invoice = invoice.Replace("?", " ");
            }
            Json = invoice;
            string cSignedDocument = "";
           // string cError = "";
            string signe = "";
           

            if (v.have_token) if (new TokenSigner().SignDocument(Json, db.pinToken, ref cSignedDocument, ref v.cErrortoken)) signe = TokenSigner.Cades;
            db.log_error("-------------Token------------------------01");
            //  db.log_error("Json:" + Json);
            // db.log_error(" v.pinToken:" + v.pinToken.Trim());
            //db.log_error("have_token:" + v.have_token + "");
            //db.log_error("pinToken:" + db.pinToken + "");
            //db.log_error("Certfication:" + db.Certfication + "");
            //db.log_error("cSignedDocument:" + cSignedDocument);
            db.log_error("cError:" + v.cErrortoken);
            db.log_error("signe:" + signe);
            if (v.cErrortoken != "")//CKR_PIN_INCORRECT
            {
                  return v.cErrortoken;
            }
            string x = ",\"signatures\" : \n [  \n{ \"signatureType\" : \"I\" , \"value\" : \"" + TokenSigner.Cades + "\" \n } \n ] \n }";
           // db.log_error("TokenSigner.Cades:"+TokenSigner.Cades);
            Json = "\n{ \n\t\"documents\":\n [ \n" + invoice + x + "   \n]\n }\n";

            //save Einvoice
            //  db.create_txt_inEinv(v.invoicenum, Json);
            db.log_error("Json:>>>     \n"+Json);
            return Json;
        }
     
       
          
        
        static public  string  LogIn_portal(string ID,string SECERIT,ref string acc_token,ref string error)
        {
            ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)((param0, param1, param2, param3) => true);
            //string ID ="88926f5b-0b96-4faa-87b5-3231649d937e";
            //string Secerit = "d24b0bc6-a26e-4589-9abf-c863722cd1ff";
            string test = "https://id.preprod.eta.gov.eg/connect/token";
            string live = "https://id.eta.gov.eg/connect/token";
            string txt = "";
            bool ISLIVE = v.isLive;
            
            if (ISLIVE)
            {
                RestClient restClient = new RestClient(live);
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                restRequest.AddHeader("Cookie", "3f6bf69972563c3e0e619b78edf73035=17f042c536111c9797e4c765ba6d38ff");
                restRequest.AddParameter("grant_type", "client_credentials");
                restRequest.AddParameter("Client_ID", (ID.Trim()));
                restRequest.AddParameter("Client_Secret", (SECERIT.Trim()));
                txt = restClient.Execute((IRestRequest)restRequest).Content;
            }
            else
            {

                RestClient restClient = new RestClient(test);
                restClient.Timeout = -1;
                RestRequest restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                restRequest.AddHeader("Cookie", "3f6bf69972563c3e0e619b78edf73035=17f042c536111c9797e4c765ba6d38ff");
                restRequest.AddParameter("grant_type", "client_credentials");
                restRequest.AddParameter("Client_ID", (ID.Trim()));
                restRequest.AddParameter("Client_Secret", (SECERIT.Trim()));
                txt = restClient.Execute((IRestRequest)restRequest).Content;

            }

            try
            {
                string output= "";
                getBetween(txt, "access_token", "\",\"expires_in", ref output);
                output =output.Remove(0, 3);
                //  tokken = output;
                acc_token = output;
                if (output.Length > 10)
                {
                   // frm_einv f = new frm_einv();
                   // f.Show();
                    //frm_login f = new frm_login();
                    //f.Show();
                   // this.Visible = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                error = "مش عارف اكلم بورتال الضرائب ومش عارف اجيب جنريت كود ممكن يكون سيكرت غلط او اي دي او السكريت او رقم النشاط غلط او اكسبير او في مشكلة في الحتا دية";
                db.log_error(ex.Message+"\n"+ error);
            }
            db.log_error("acc_token:" + acc_token);
            return acc_token;

        }
    
        public static string getBetween(string strSource, string strStart, string strEnd, ref string outbut)
        {
            if (!strSource.Contains(strStart) || !strSource.Contains(strEnd))
                return "";
            int startIndex = strSource.IndexOf(strStart, 0) + strStart.Length;
            int num = strSource.IndexOf(strEnd, startIndex);
            outbut = strSource.Substring(startIndex, num - startIndex);
            return strSource.Substring(startIndex, num - startIndex);
        }
        public static string  send_e_invoice(ref string body,ref string message,ref string uuid)
        {
            try
            {
                db.log_error("************************************************");
                string api_invoice_test = "https://api.preprod.invoicing.eta.gov.eg/api/v1/documentsubmissions";
                string api_invoice_live = "https://api.invoicing.eta.gov.eg/api/v1/documentsubmissions";
                string x = "";
                x = api_invoice_live;
                //if (v.isLive)
                //{
                //    x = api_invoice_live;
                //}
                //else
                //{
                //    x = api_invoice_test;
                //}
                var client = new RestClient(x);
                client.Timeout = -1;
                client.FollowRedirects = false;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + v.acc_token_login);
               // var body = body;
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
               // db.log_error(response.Content + "");
                message = response.Content;
                string txt_portal = response.Content;
                //1-error not found 
                if (!message.Contains("error"))
                {
                    getBetween(txt_portal, "uuid", "\",\"",ref uuid);
                    uuid = uuid.Remove(0, 3);
                    //{"submissionId":null,"acceptedDocuments":[],"rejectedDocuments":[{"internalId":"SI-0052352  ","error":{"code":"1","message":"Validation Error","target":"SI-0052352  ","propertyPath":null,"details":[{"code":"CF313","message":"Issuance date time value is out of the range of submission workflow parameter","target":"DatetimeIssued","propertyPath":"document.datetimeissued","details":null}]}}]}
                    // if invoice == invoice
                    // db.Run("update sale_hd set uuid='" + uuid + "',state_e='1' where sale_hd_id='" + v.invoicenum + "'");
                    db.Run("update TaxQue set iStatus='1',cUUID='" + uuid + "' where cDocNumber='" + v.invoicenum + "' ");
                    db.Run("update SInv set cUUID='"+ uuid + "' where cInvoicNum='" + v.invoicenum + "' ");
                    db.Run("update sRet set cUUID='" + uuid + "' where cInvoicNum='" + v.invoicenum + "' ");


                    try
                    {
                        db.Run("update SInv set cAdd5='" + message + "' where cInvoicNum='" + v.invoicenum + "'");

                    }
                    catch (Exception)
                    {
                    }
                    //save Einvoice
                    db.create_txt_inEinv(v.invoicenum, body);
                    db.create_txt_inEinv(uuid, body);


                }
                //2-found Error
                else
                {
                   // db.create_txt_inEinv(v.invoicenum, message);
                 //   string message_short = message;
                 //   string xx;
                //    getBetween(message, "","\",\"", ref xx);
                    //db.Run("update sale_hd set message='" + message + "',uuid='"+uuid+"',state_e='3' where sale_hd_id='"+v.invoicenum+"'");
                    // db.Run("update sale_hd set message='" + message + "',uuid='" + uuid + "',state_e='3' where sale_hd_id='" + v.invoicenum + "'");
                    db.Run("update TaxQue set iStatus='3',cUUID='" + uuid + "',cError='"+ message + "' where cDocNumber='" + v.invoicenum + "' ");
                 ///   db.Run("update SInv set cAdd5='" + message + "' where cInvoicNum='" + v.invoicenum + "'");

                    db.create_txt_inEinv(v.invoicenum, body);
                    db.create_txt_inEinv(uuid, body);



                    db.log_error(message);


                }
                //save Einvoice
                db.create_txt_inEinv(uuid,body);

                if (uuid == "")
                {
                    Console.WriteLine(message);
                    db.log_error(message);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                db.log_error(ex.Message);
            }

            return uuid;

        }

     
       public static void final_Einvoice(ref string error)
        {

            // db.Open();
            //string mesg=db.GetData("select cError from TaxQue where cDocNumber='SI-0052352'").Rows[0][0] + "";
            //string xx = "";
            //Einvoice.getBetween(mesg, "message\":\"Validation Error", "\"message\":\"Issuance", ref xx);

            //1-Open Data base and load Data
            //===============================================================================================================================
            string Error = "";
            db.Open(ref Error);
            if (Error != "") { db.log_error(Error); return; }
            load_main.load_basec_Data();
            //string error_login="";
            Einvoice.LogIn_portal(db.id, db.secret, ref v.acc_token_login,ref v.error_login);
            //====================================
            //2-Detect Token
            //===============================================================================================================================
           // v.have_token = true;
            if (v.have_token)
            {
                if (new TokenSigner().IsTokenPlagin() == false) return;
            }
            else
            {
                Console.WriteLine("work without token 0.9");
                db.log_error("work without token 0.9 ");
            }

            //::::::::::::::START TIMER :===============================
            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            //3-GEt_Documents numbers
            //===============================================================================================================================
            DataTable dtDoc = new DataTable();
            db.GetData_DGV("select cDocNumber,cMode from TaxQue where iStatus='0'", dtDoc);
            //select cDocNumber,cMode from TaxQue where iStatus='0'

            //                            LOOP TO GET LIST OF DOCUMENTS TO SEND 
            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            for (int i = 0; i < dtDoc.Rows.Count; i++)
            {
               // db.log_error(dtDoc.Rows[i][0].ToString()+"   "+ dtDoc.Rows[i][1].ToString());
                //4-Get invoice number and Generat_JSON
                //===============================================================================================================================
                v.invoicenum = dtDoc.Rows[i][0] + "";
                string dateTimeIssued;
                string dateValidity;
                string currencySold = "";
                string vcs_code;
                bool incloud_1_vat;
                bool FoundcurrencySold;
               Decimal currencyExchangeRate = 0;
                bool exemption_vat = false;
                string exemp_bool = "";
                string subType_vcs = "";
                string subType_rat_vcs = "";
                Decimal fRate = 1;
                string documentType = "";
                DataTable dt = new DataTable();
            //    string quer1 = "select ISNULL(max(fDiscTax),0) from SInv where cInvoicNum='" + v.invoicenum + "'";
             //   db.log_error(quer1);
                double isVAT_ADD = Convert.ToDouble(db.GetData("select ISNULL(max(fDiscTax),0) from SInv where cInvoicNum='" + v.invoicenum + "'").Rows[0][0]);
            //    db.log_error("isVAT_ADD:"+isVAT_ADD );

                if (isVAT_ADD == 0)
                {
                    //vat incloud 14 %
                    //if invoice 122
                    if (dtDoc.Rows[i][1]+"".Trim()=="122")
                    {
                      // db.log_error("select d.cItName as description,(select top 1 cCodeType from item where cCode=d.cItCode) as itemType,(select top 1 cUItemCode from item where cCode=d.cItCode)as itemCode,d.cTransUnit as unitType,d.fTransQty,d.cItCode as internalCode,(d.fTransQty*d.fTransUnitPrice*h.fRate) as salesTotal,d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))+(d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))*(select t.fValue/100 from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode)) as total,'valueDifference','totalTaxableFees',d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate)) as netTotal  ,'itemsDiscount',(select top 1 cTaxCode from Currency where aCode=h.cCurrency) as currencySold  ,d.fTransUnitPrice*h.fRate as amountEGP ,  ((d.fDiscount)/(d.fTransUnitPrice))*100 as rate_discount,d.fDiscount*h.fRate*d.fTransQty as amount_discount,(select t.cTaxableType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as taxType ,d.fTax*h.fRate as amount,(select t.cTaxableSubType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as subType,(select t.fValue from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as rate ,h.fDiscount as extraDiscountAmount ,h.dIssueDate as dateTimeIssued ,h.dPayDate as dateValidity ,h.cVcCode,cName,d.fTransUnitPrice as amountSold,h.fRate as currencyExchangeRate ,h.cAttachNo as salesOrderReference,h.cComment as salesOrderDescription,h.cAttachNo as proformaInvoiceNumber from SInv_D d left join SInv h on d.cInvoicNum=h.cInvoicNum where d.cInvoicNum= '" + v.invoicenum + "'");
                        db.GetData_DGV("select d.cItName as description,(select top 1 cCodeType from item where cCode=d.cItCode) as itemType,(select top 1 cUItemCode from item where cCode=d.cItCode)as itemCode,d.cTransUnit as unitType,d.fTransQty,d.cItCode as internalCode,(d.fTransQty*d.fTransUnitPrice*h.fRate) as salesTotal,d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))+(d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))*(select t.fValue/100 from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode)) as total,'valueDifference','totalTaxableFees',d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate)) as netTotal  ,'itemsDiscount',(select top 1 cTaxCode from Currency where aCode=h.cCurrency) as currencySold  ,d.fTransUnitPrice*h.fRate as amountEGP ,  ((d.fDiscount)/(d.fTransUnitPrice))*100 as rate_discount,d.fDiscount*h.fRate*d.fTransQty as amount_discount,(select t.cTaxableType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as taxType ,d.fTax*h.fRate as amount,(select t.cTaxableSubType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as subType,(select t.fValue from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as rate ,h.fDiscount as extraDiscountAmount ,h.dIssueDate as dateTimeIssued ,h.dPayDate as dateValidity ,h.cVcCode,cName,d.fTransUnitPrice as amountSold,h.fRate as currencyExchangeRate ,h.cAttachNo as salesOrderReference,h.cComment as salesOrderDescription,h.cAttachNo as proformaInvoiceNumber from SInv_D d left join SInv h on d.cInvoicNum=h.cInvoicNum where d.cInvoicNum= '" + v.invoicenum + "'", dt);
                        fRate = Convert.ToDecimal(db.GetData("select fRate from SInv where cInvoicNum='" + v.invoicenum + "'").Rows[0][0] + "");
                        documentType = "i";
                      //  db.log_error(dt.Rows[i][0]+""+ dt.Rows[i][1] + ""+ dt.Rows[i][2] + ""+ dt.Rows[i][3] + ""+ dt.Rows[i][4] + ""+ dt.Rows[i][5] + ""+ dt.Rows[i][6] + ""+ dt.Rows[i][7] + ""+ dt.Rows[i][8] + "");
                    }
                    else // if re invoice 123 
                    {
                        db.GetData_DGV("select d.cItName as description,(select top 1 cCodeType from item where cCode=d.cItCode) as itemType,(select top 1 cUItemCode from item where cCode=d.cItCode)as itemCode,d.cTransUnit as unitType,d.fTransQty,d.cItCode as internalCode,(d.fTransQty*d.fTransUnitPrice*h.fRate) as salesTotal,d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))+(d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))*(select t.fValue/100 from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode)) as total,'valueDifference','totalTaxableFees',d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate)) as netTotal  ,'itemsDiscount',(select top 1 cTaxCode from Currency where aCode=h.cCurrency) as currencySold  ,d.fTransUnitPrice*h.fRate as amountEGP ,  ((d.fDiscount)/(d.fTransUnitPrice))*100 as rate_discount,d.fDiscount*h.fRate*d.fTransQty as amount_discount,(select t.cTaxableType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as taxType ,d.fTax*h.fRate as amount,(select t.cTaxableSubType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as subType,(select t.fValue from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as rate ,h.fDiscount as extraDiscountAmount ,h.dIssueDate as dateTimeIssued ,h.dPayDate as dateValidity ,h.cVcCode,cName,d.fTransUnitPrice as amountSold,h.fRate as currencyExchangeRate ,h.cAttachNo as salesOrderReference,h.cComment as salesOrderDescription,h.cAttachNo as proformaInvoiceNumber from SRet_D d left join SRet h on d.cInvoicNum=h.cInvoicNum where d.cInvoicNum= '" + v.invoicenum + "'", dt);
                        fRate = Convert.ToDecimal(db.GetData("select fRate from SRet where cInvoicNum='" + v.invoicenum + "'").Rows[0][0] + "");
                        documentType = "c";
                    }
                    exemp_bool = db.GetData("select lTaxExemp from vcs where cCode='" + dt.Rows[0][23] + "" + "'").Rows[0][0] + "";
                    if (exemp_bool == "0")
                    {
                        exemption_vat = false;
                    }
                    else//customer exepemption tax tax ==0
                    {
                        exemption_vat = true;
                        subType_vcs = db.GetData("select t.cTaxableSubType from vcs v left join TaxPlan t on v.cTaxPlan=t.cCode  where v.cCode='" + dt.Rows[0][23] + "'").Rows[0][0] + "";
                        subType_rat_vcs = "0";
                    }
                    //get frate currency
                    if (fRate > 1)
                    {
                    //    amountSold = Convert.ToDecimal(dt.Rows[0][25]);
                        currencyExchangeRate = Convert.ToDecimal(dt.Rows[0][26]);
                        currencySold = dt.Rows[0][12] + "".Trim();
                        FoundcurrencySold = true;
                    }
                    else
                    {
                        currencySold = db.GetData(" select cTaxCode from Currency  where lMain=1").Rows[0][0] + "".Trim();
                        FoundcurrencySold = false;
                    }
                    incloud_1_vat = false;
                    dateTimeIssued = db.convert_date_aswaq((dt.Rows[0][21]) + "");
                    dateValidity = db.convert_date_aswaq((dt.Rows[0][22]) + "");
                }
                else
                {
                    //vat incloud 14%+1%
                    incloud_1_vat = true;
                    if (dtDoc.Rows[i][1] + "".Trim() == "122")
                    {
                        // db.log_error("select d.cItName as description,(select top 1 cCodeType from item where cCode=d.cItCode) as itemType,(select top 1 cUItemCode from item where cCode=d.cItCode)as itemCode,d.cTransUnit as unitType,d.fTransQty,d.cItCode as internalCode,(d.fTransQty*d.fTransUnitPrice*h.fRate) as salesTotal,d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))+(d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))*(select t.fValue/100 from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode)) as total,'valueDifference','totalTaxableFees',d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate)) as netTotal  ,'itemsDiscount',(select top 1 cTaxCode from Currency where aCode=h.cCurrency) as currencySold  ,d.fTransUnitPrice*h.fRate as amountEGP ,  ((d.fDiscount)/(d.fTransUnitPrice))*100 as rate_discount,d.fDiscount*h.fRate*d.fTransQty as amount_discount,(select t.cTaxableType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as taxType ,d.fTax*h.fRate as amount,(select t.cTaxableSubType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as subType,(select t.fValue from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as rate ,h.fDiscount as extraDiscountAmount ,h.dIssueDate as dateTimeIssued ,h.dPayDate as dateValidity ,h.cVcCode,cName,d.fTransUnitPrice as amountSold,h.fRate as currencyExchangeRate ,h.cAttachNo as salesOrderReference,h.cComment as salesOrderDescription,h.cAttachNo as proformaInvoiceNumber from SInv_D d left join SInv h on d.cInvoicNum=h.cInvoicNum where d.cInvoicNum= '" + v.invoicenum + "'");
                        db.GetData_DGV("select d.cItName as description,(select top 1 cCodeType from item where cCode=d.cItCode) as itemType,(select top 1 cUItemCode from item where cCode=d.cItCode)as itemCode,d.cTransUnit as unitType,d.fTransQty,d.cItCode as internalCode,(d.fTransQty*d.fTransUnitPrice*h.fRate) as salesTotal,d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))+(d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))*(select t.fValue/100 from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode)) as total,'valueDifference','totalTaxableFees',d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate)) as netTotal  ,'itemsDiscount',(select top 1 cTaxCode from Currency where aCode=h.cCurrency) as currencySold  ,d.fTransUnitPrice*h.fRate as amountEGP ,  ((d.fDiscount)/(d.fTransUnitPrice))*100 as rate_discount,d.fDiscount*h.fRate*d.fTransQty as amount_discount,(select t.cTaxableType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as taxType ,d.fTax*h.fRate as amount,(select t.cTaxableSubType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as subType,(select t.fValue from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as rate ,h.fDiscount as extraDiscountAmount ,h.dIssueDate as dateTimeIssued ,h.dPayDate as dateValidity ,h.cVcCode,cName,d.fTransUnitPrice as amountSold,h.fRate as currencyExchangeRate ,h.cAttachNo as salesOrderReference,h.cComment as salesOrderDescription,h.cAttachNo as proformaInvoiceNumber , (select top 1 cName1 from TaxAddPlan where cCode = (select top 1 cDiscTax from Terms where eCode = h.cTerm))as taxType_add ,(select top 1 cName2 from TaxAddPlan where cCode = (select top 1 cDiscTax from Terms where  eCode = h.cTerm))as subType_add ,(select top 1 fValue from TaxAddPlan where cCode = (select top 1 cDiscTax from Terms where  eCode = h.cTerm))as rate_add ,(d.fTransQty * ((d.fTransUnitPrice * h.fRate) - (d.fDiscount * h.fRate))) * ((select top 1 fValue from TaxAddPlan where cCode = (select top 1 cDiscTax from Terms where  eCode = h.cTerm)))/ 100 as amount_add  from SInv_D d left  join SInv h on d.cInvoicNum = h.cInvoicNum where d.cInvoicNum ='" + v.invoicenum + "'", dt);
                        fRate = Convert.ToDecimal(db.GetData("select fRate from SInv where cInvoicNum='" + v.invoicenum + "'").Rows[0][0] + "");
                        documentType = "i";
                       
                        //  db.log_error(dt.Rows[i][0]+""+ dt.Rows[i][1] + ""+ dt.Rows[i][2] + ""+ dt.Rows[i][3] + ""+ dt.Rows[i][4] + ""+ dt.Rows[i][5] + ""+ dt.Rows[i][6] + ""+ dt.Rows[i][7] + ""+ dt.Rows[i][8] + "");
                    }
                    else // if re invoice 123 
                    {
                        db.GetData_DGV("select d.cItName as description,(select top 1 cCodeType from item where cCode=d.cItCode) as itemType,(select top 1 cUItemCode from item where cCode=d.cItCode)as itemCode,d.cTransUnit as unitType,d.fTransQty,d.cItCode as internalCode,(d.fTransQty*d.fTransUnitPrice*h.fRate) as salesTotal,d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))+(d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate))*(select t.fValue/100 from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode)) as total,'valueDifference','totalTaxableFees',d.fTransQty*((d.fTransUnitPrice*h.fRate)-(d.fDiscount*h.fRate)) as netTotal  ,'itemsDiscount',(select top 1 cTaxCode from Currency where aCode=h.cCurrency) as currencySold  ,d.fTransUnitPrice*h.fRate as amountEGP ,  ((d.fDiscount)/(d.fTransUnitPrice))*100 as rate_discount,d.fDiscount*h.fRate*d.fTransQty as amount_discount,(select t.cTaxableType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as taxType ,d.fTax*h.fRate as amount,(select t.cTaxableSubType from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as subType,(select t.fValue from item i left join TaxPlan t on i.cTaxPlan=t.cCode  where i.cCode=d.cItCode) as rate ,h.fDiscount as extraDiscountAmount ,h.dIssueDate as dateTimeIssued ,h.dPayDate as dateValidity ,h.cVcCode,cName,d.fTransUnitPrice as amountSold,h.fRate as currencyExchangeRate ,h.cAttachNo as salesOrderReference,h.cComment as salesOrderDescription,h.cAttachNo as proformaInvoiceNumber from SRet_D d left join SRet h on d.cInvoicNum=h.cInvoicNum where d.cInvoicNum= '" + v.invoicenum + "'", dt);
                        fRate = Convert.ToDecimal(db.GetData("select fRate from SRet where cInvoicNum='" + v.invoicenum + "'").Rows[0][0] + "");
                        documentType = "c";
                    }
                    exemp_bool = db.GetData("select lTaxExemp from vcs where cCode='" + dt.Rows[0][23] + "" + "'").Rows[0][0] + "";
                    if (exemp_bool == "0")
                    {
                        exemption_vat = false;
                    }
                    else//customer exepemption tax tax ==0
                    {
                        exemption_vat = true;
                        subType_vcs = db.GetData("select t.cTaxableSubType from vcs v left join TaxPlan t on v.cTaxPlan=t.cCode  where v.cCode='" + dt.Rows[0][23] + "'").Rows[0][0] + "";
                        subType_rat_vcs = "0";
                    }
                    //get frate currency
                    if (fRate > 1)
                    {
                      //  amountSold = Convert.ToDecimal(dt.Rows[0][25]);
                        currencyExchangeRate = Convert.ToDecimal(dt.Rows[0][26]);
                        currencySold = dt.Rows[0][12] + "".Trim();
                        FoundcurrencySold = true;

                    }
                    else
                    {
                        currencySold = db.GetData(" select cTaxCode from Currency  where lMain=1").Rows[0][0] + "".Trim();
                        FoundcurrencySold = false;

                    }

                    dateTimeIssued = db.convert_date_aswaq((dt.Rows[0][21]) + "");
                    dateValidity = db.convert_date_aswaq((dt.Rows[0][22]) + "");
                }
                string json = "";
                vcs_code = (dt.Rows[0][23]) + "";
                //Receiver Data
                string receiver_regionCity = db.GetData("select ISNULL(max(cCity),'') from vcs where cCode = '" + vcs_code + "'").Rows[0][0] + "";
                string receiver_country = db.GetData("select ISNULL(max(cCountry),'') from vcs where cCode = '" + vcs_code + "'").Rows[0][0] + "";
                string receiver_governate = db.GetData("select ISNULL(max(cGovernate), '') from vcs where cCode = '" + vcs_code + "'").Rows[0][0] + "";
                string receiver_street = db.GetData("select ISNULL(max(cStreet), '') from vcs where cCode = '" + vcs_code + "'").Rows[0][0] + "";
                string receiver_buildingNumber = db.GetData("select ISNULL(max(cBuildNum), '') from vcs where cCode = '" + vcs_code + "'").Rows[0][0] + "";
                string receiver_type = db.GetData("select ISNULL(max([cType]),'') from vcs where cCode = '" + vcs_code + "'").Rows[0][0] + "";
                string receiver_id = db.GetData("select ISNULL(max([cTaxNum]),'') from vcs where cCode = '" + vcs_code + "'").Rows[0][0] + "";
                string receiver_name = db.GetData("select ISNULL(max([cName1]),'') from vcs where cCode = '" + vcs_code + "'").Rows[0][0] + "";
                //Other Description in Invoice

                string no_invoice_internalID = v.invoicenum + "";
                string purchaseOrderReference = "";
                string salesOrderReference = dt.Rows[0][27] +"";
                string salesOrderDescription = dt.Rows[0][28] +"";
                if (salesOrderDescription.Contains("\"") )
                {
                    salesOrderDescription = salesOrderDescription.Replace("\"", " ");
                   
                }
                string proformaInvoiceNumber = dt.Rows[0][29] + "";
                Einvoice.Generat_JSON(ref json, ref dt,
                ref documentType,
                ref receiver_country,
                ref subType_rat_vcs,
                ref subType_vcs,
                ref exemption_vat,
           
                ref currencyExchangeRate,
                ref  FoundcurrencySold,
                ref currencySold,
                ref dateTimeIssued,
                ref dateValidity,
                ref receiver_regionCity,
                ref receiver_governate,
                ref receiver_street,
                ref receiver_buildingNumber,
                ref receiver_type,
                ref receiver_id,
                ref receiver_name,
                ref no_invoice_internalID,
                ref purchaseOrderReference,
                ref salesOrderReference,
                ref salesOrderDescription,
                ref proformaInvoiceNumber,
                ref incloud_1_vat
                );

                //4-Send Invoice
                //===============================================================================================================================
                string message = "";
                string UUID = "";
                Einvoice.send_e_invoice(ref json, ref message, ref UUID);

            }
        }




       



    }
}
