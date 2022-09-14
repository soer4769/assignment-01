using Xunit;
using Assignment1;

namespace Assignment1.Tests;

public class IteratorsTests
{

    [Fact]
    public void Flatten_return_single_array_of_all_numbers()
    {
        //Arrange
        int[][] arrayOfArrays = { new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 } };
        
        //act
        IEnumerable<int> singleArray = Iterators.Flatten(arrayOfArrays);
        
        //Assert
        Assert.Equal(singleArray,new []{0,1,2,3,4,5,6,7,8});
    }
    
    [Fact]
    public void Filter_return_only_even_numbers()
    {
        //Arrange
        int[] array = { 1,2,3,4,5,6};
        bool IsEven(int x) => x % 2 == 0;
        
        //act
        IEnumerable<int> evens = Iterators.Filter(array,IsEven);
        
        //Assert
        Assert.Equal(evens,new []{2,4,6});
    }
    
    
    
    
    
}