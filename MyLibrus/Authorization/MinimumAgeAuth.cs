using Microsoft.AspNetCore.Authorization;

namespace MyLibrus
{
    public class MinimumAgeAut : IAuthorizationRequirement
    {
        // this interface does not has any class, thats mean that is only some kind of marker, which shows us that this class is for Authorizaiton

        public int MinAge { get;}

        public MinimumAgeAut(int minAge)
        {
            MinAge = minAge;
        }
    }
}

 