using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilvioStore.Domain.StoreContext.ValueObjects;

namespace SilvioStore.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    private Document validDocument;

    private Document invalidDocument;
    
    public DocumentTests()
    {
        validDocument = new Document("28659170377");
        invalidDocument = new Document("12345678910");
    }
    
    
    [TestMethod]
    public void ShouldReturnNotificationWhenDocumentIsNotValid()
    {
        var document = new Document("12345678910");
        Assert.AreEqual(false, invalidDocument.IsValid);
        Assert.AreEqual(1, invalidDocument.Notifications.Count);
    }

    [TestMethod]
    public void ShouldReturnNotificationWhenDocumentIsValid()
    {
        var document = new Document("28659170377");
        Assert.AreEqual(true, validDocument.IsValid);
        Assert.AreEqual(0, validDocument.Notifications.Count);
    }

}