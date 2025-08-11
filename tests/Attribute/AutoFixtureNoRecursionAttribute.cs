using AutoFixture;
using AutoFixture.Xunit2;
using TaskService.Data.Models;


public class AutoFixtureNoRecursionAttribute: AutoDataAttribute
{ 
    public AutoFixtureNoRecursionAttribute(): base(() => new Fixture().Customize(new NoRecursionCustomization()))
    {

    }

}



public class NoRecursionCustomization : ICustomization
{


    public void Customize(IFixture fixture)
    {
        fixture.Behaviors.Remove(new ThrowingRecursionBehavior());  
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        fixture.Customize<User>(c => c.Without(u => u.Tasks));
        fixture.Customize<TaskModel>(c => c.Without(t => t.AssignedUser));
    }
}