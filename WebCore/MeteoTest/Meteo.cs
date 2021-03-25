using Xunit;

namespace Meteo.E2E.Test
{
    public partial class Meteo
    {

        [Fact] public void OakAll() => Assert.True(GetOakAll());
      
        [Fact] public void Page63() => Assert.True(GetPage());
       
        [Fact] public void Err63() => Assert.False(GetApiErr());
       
    }
}
