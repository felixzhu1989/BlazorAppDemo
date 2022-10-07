export  async function callIsolationMethod(instanceObject) {
    const message = await instanceObject.invokeMethodAsync("GetValueFromIsolation");
    alert(`Message from Instance:${message}`);
}