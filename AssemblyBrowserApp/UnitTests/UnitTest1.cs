using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyBrowserLib;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    { 
    AssemblyReader AssemblyTree;

    [TestInitialize]
    public void Initialize()
    {
        AssemblyTree = new AssemblyReader(".\\TestProject.dll");
    }

    [TestMethod]
    public void NamespacesTest()
    {
        Assert.IsNotNull(AssemblyTree.Namespaces);
        Assert.AreEqual(AssemblyTree.Namespaces[0].Name, "TestProject");
    }

    [TestMethod]
    public void DataTypesTest()
    {
        foreach (DatatypeInfo datatype in AssemblyTree.Namespaces[0].DataTypes)
        {
            Assert.IsNotNull(datatype);
            Assert.AreNotEqual(datatype.Name, String.Empty);
        }
    }

    [TestMethod]
    public void EmptyClassTest()
    {
        // EmptyClass
        Assert.AreEqual(AssemblyTree.Namespaces[0].DataTypes[0].shortName, "EmtpyClass");
        Assert.AreEqual(AssemblyTree.Namespaces[0].DataTypes[0].fields.Count, 0);
        Assert.AreEqual(AssemblyTree.Namespaces[0].DataTypes[0].properties.Count, 0);
        Assert.AreEqual(AssemblyTree.Namespaces[0].DataTypes[0].methods.Count, 4);
    }

    [TestMethod]
    public void NotEmptyClassTest()
    {
        // SimpleClass
        Assert.AreEqual(AssemblyTree.Namespaces[0].DataTypes[1].shortName, "SimpleClass");
        Assert.IsTrue(AssemblyTree.Namespaces[0].DataTypes[1].fields.Count > 0);
        Assert.IsTrue(AssemblyTree.Namespaces[0].DataTypes[1].properties.Count > 0);
        Assert.IsTrue(AssemblyTree.Namespaces[0].DataTypes[1].methods.Count > 0);
    }

    [TestMethod]
    public void NamesTest()
    {
        Assert.AreEqual(AssemblyTree.Namespaces[0].DataTypes[1].fields[0].name, "ID");
        Assert.AreEqual(AssemblyTree.Namespaces[0].DataTypes[1].properties[0].name, "SomeInfo");
        Assert.AreEqual(AssemblyTree.Namespaces[0].DataTypes[1].methods[0].name, "ToString");
    }
}
}
