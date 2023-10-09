public record CaseDTO
{
    public long CaseId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
public CaseDTO(Case _case)
{
    CaseId = _case.CaseId;
    Name = _case.Name;
    Price = _case.Price;
    Description = _case.Description;
    Created = _case.Created;
    Updated = _case.Updated;
}
}