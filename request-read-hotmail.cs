request.cookies = cookies;
request.header["Authorization"] = "Bearer " + token;
request.header["Client-Session-ID"] = Guid.NewGuid().ToString();
string postJSON = "{\"Cvid\":\"" + Guid.NewGuid().ToString() + "\",\"Scenario\":{\"Name\":\"owa.react\"},\"TimeZone\":\"W. Europe Standard Time\",\"TextDecorations\":\"Off\",\"EntityRequests\":[{\"EntityType\":\"Conversation\",\"Filter\":{\"Or\":[{\"Term\":{\"DistinguishedFolderName\":\"msgfolderroot\"}},{\"Term\":{\"DistinguishedFolderName\":\"DeletedItems\"}}]},\"From\":0,\"PropertySet\":\"ProvenanceOptimized\",\"Provenances\":[\"Exchange\"],\"Query\":{\"QueryString\":\"to:" + email + "\"},\"QueryAlterationOptions\":{\"EnableSuggestion\":true,\"EnableAlteration\":true},\"RefiningQueries\":null,\"Size\":25,\"Sort\":[{\"Field\":\"Score\",\"SortDirection\":\"Desc\",\"Count\":3},{\"Field\":\"Time\",\"SortDirection\":\"Desc\"}]}]}";
string e = request.postJSON("https://outlook.live.com/search/api/v1/query", postJSON);
var listID = e.SplitAt(e.AllIndexesOf("\"ConversationId\":{\"Id\":\"").ToArray());
MatchCollection matches = Regex.Matches(e, "\"ConversationTopic\":\"([^\"]+)");
int mailIndex = 0;
foreach (Match match1 in matches)
{
    mailIndex++;
    string line = match1.Groups[1].Value;
    Match match2 = Regex.Match(line, "\\d+");
    if (match2.Success)
    {
        if (listID.Length > mailIndex)
        {
            string id = listID[mailIndex].fetchValue("{\"Id\":\"", "\"");
            request.header["X-OWA-CANARY"] = (request.cookies + ";").fetchValue("X-OWA-CANARY=", ";");
            request.header["Action"] = "GetConversationItems";
            e = request.postJSON("https://outlook.live.com/owa/0/service.svc?action=GetConversationItems&app=Mail", "{\"__type\":\"GetConversationItemsJsonRequest:#Exchange\",\"Header\":{\"__type\":\"JsonRequestHeaders:#Exchange\",\"RequestServerVersion\":\"V2017_08_18\"},\"Body\":{\"__type\":\"GetConversationItemsRequest:#Exchange\",\"Conversations\":[{\"__type\":\"ConversationRequestType:#Exchange\",\"ConversationId\":{\"__type\":\"ItemId:#Exchange\",\"Id\":\"" + id + "\"},\"SyncState\":\"\"}],\"ShapeName\":\"ItemPart\"}}");
            string link = e.fetchValue("/recover/code/", "\"");
            if (!string.IsNullOrEmpty(link))
            {
                link = Regex.Unescape(link.Replace("&amp;", "&"));
                link = Regex.Replace(link, "&exp_locale=[^&]+", "");
                return "https://www.facebook.com/recover/code/" + link;
            }
        }
    }
}
