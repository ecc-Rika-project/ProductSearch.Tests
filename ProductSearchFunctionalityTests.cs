namespace ProductSearch.Tests;

using System;
using System.Linq;
using Xunit;
using ProductSearch;

public class ProductSearchFunctionalityTests
{
    [Fact]
    public void SearchProducts_ShouldReturnMatchingProducts_WhenSearchTermMatchesNameOrDescription()
    {
        // Arrange
        var repository = new ProductRepository();
        var searchTerm = "Dress";

        // Act
        var results = repository.SearchProducts(searchTerm).ToList();

        // Assert
        Assert.Single(results);
        Assert.Equal("Dress", results[0].Name);
    }

    [Fact]
    public void SearchProducts_ShouldReturnEmpty_WhenSearchTermDoesNotMatchAnyProduct()
    {
        // Arrange
        var repository = new ProductRepository();
        var searchTerm = "NonExistentProduct";

        // Act
        var results = repository.SearchProducts(searchTerm);

        // Assert
        Assert.Empty(results);
    }

    [Fact]
    public void SearchProducts_ShouldBeCaseInsensitive()
    {
        // Arrange
        var repository = new ProductRepository();
        var searchTerm = "pants"; // lowercase

        // Act
        var results = repository.SearchProducts(searchTerm).ToList();

        // Assert
        Assert.Single(results);
        Assert.Equal("Pants", results[0].Name);
    }

    [Fact]
    public void SearchProducts_ShouldReturnEmpty_WhenSearchTermIsNullOrWhitespace()
    {
        // Arrange
        var repository = new ProductRepository();

        // Act
        var results1 = repository.SearchProducts(null);
        var results2 = repository.SearchProducts("");

        // Assert
        Assert.Empty(results1);
        Assert.Empty(results2);
    }
}
