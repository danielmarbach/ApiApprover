﻿using System.Threading.Tasks;
using ApiApproverTests.Examples;
using Xunit;

namespace ApiApproverTests
{
    public class Method_async : ApiGeneratorTestsBase
    {
        [Fact]
        public void Should_output_async_void_method()
        {
            AssertPublicApi<MethodAsyncVoid>(
@"namespace ApiApproverTests.Examples
{
    public class MethodAsyncVoid
    {
        public MethodAsyncVoid() { }
        public async void AsyncMethod() { }
    }
}");
        }

        [Fact]
        public void Should_output_async_method_with_return_value()
        {
            AssertPublicApi<MethodAsyncReturnValue>(
@"namespace ApiApproverTests.Examples
{
    public class MethodAsyncReturnValue
    {
        public MethodAsyncReturnValue() { }
        public async System.Threading.Tasks.Task<string> AsyncMethod() { }
    }
}");
        }
    }

    // ReSharper disable UnusedMember.Global
    // ReSharper disable CSharpWarnings::CS1998
    // ReSharper disable ClassNeverInstantiated.Global
#pragma warning disable 1998
    namespace Examples
    {
        public class MethodAsyncVoid
        {
            public async void AsyncMethod()
            {
            }
        }

        public class MethodAsyncReturnValue
        {
            public async Task<string> AsyncMethod()
            {
                return await Task.FromResult("Hello world");
            }
        }
    }
#pragma warning restore 1998
    // ReSharper restore ClassNeverInstantiated.Global
    // ReSharper restore CSharpWarnings::CS1998
    // ReSharper restore UnusedMember.Global
}