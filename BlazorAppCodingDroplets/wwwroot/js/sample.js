async function callMethod() {
    const message = await DotNet.invokeMethodAsync("BlazorAppCodingDroplets", "GetValueFromMethod");
    alert(`Message from Method:${message}`);
}

async function callInstanceMethod(instanceObject) {
    const message = await instanceObject.invokeMethodAsync("GetValueFromInstance");
    alert(`Message from Instance:${message}`);
}