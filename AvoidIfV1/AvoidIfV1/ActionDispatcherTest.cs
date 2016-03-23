using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace AvoidIfV1
{
    public class ActionDispatcherTest
    {
        [Test]
        public void Should_GetAction_return_the_right_action()
        {
            var sut = new ActionDispatcher();
            var action = sut.GetAction("1", Action.Insert);
            action.Should().BeOfType<ActionOneInsert>();
            var output = action.Run();
            output.Should().Be("Action one insert");
        }
    }
}
