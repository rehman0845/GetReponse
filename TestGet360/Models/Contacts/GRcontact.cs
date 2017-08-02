//GRContact.cs

class  GRContact
{
    public string contactId{get;set;}
    public string href{get;set;}
    public string name{get;set;}
    public string email{get;set;}
    public string note{get;set;}
    public string origin{get;set;}
    public string dayOfCycle{get;set;}
    public Date createdOn{get;set;}
    public Date changedOn{get;set;}
    public string campaignId{get;set;}
    public string timeZone{get;set;}
    public string ipAddress{get;set;}
    public string activities{get;set;}
    public GRGeolocation geolocation{get;set;}
    public IList<GRCustomField> customFieldValues{get;set;}
}                                                                                                                                                   