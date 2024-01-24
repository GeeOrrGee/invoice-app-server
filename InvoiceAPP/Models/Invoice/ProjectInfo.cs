namespace InvoiceAPP.Models.Invoice;

public class ProjectInfo
{
    public ProjectInfo(DateTime createTime, int paymentTerm, string projectDescriprion)
    {
        this.creatTime          = createTime;
        this.paymentTerm        = paymentTerm;
        this.projectDescription = projectDescriprion;
    }

    public DateTime creatTime        { get; set; }
    public int paymentTerm           { get; set; }
    public string projectDescription { get; set; }
}