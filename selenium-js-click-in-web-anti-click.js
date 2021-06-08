# Code này dùng để set value và click chuột vào element khi dùng selenium mà bị web chặn

function setNativeValue(element, value) {
  let lastValue = element.value;
  element.value = value;
  let event = new Event('input', { target: element, bubbles: true });
  event.simulated = true;
  let tracker = element._valueTracker;
  if (tracker) {
    tracker.setValue(lastValue);
  }
  element.dispatchEvent(event);
}
let input = document.getElementById('{element}');
setNativeValue(input, '{value}');


const mouseClickEvents = ['mousedown', 'click', 'mouseup'];
function simulateMouseClick(element){
  mouseClickEvents.forEach(mouseEventType =>
    element.dispatchEvent(
      new MouseEvent(mouseEventType, {
         view: window,
         bubbles: true,
         cancelable: true,
         buttons: 1
  })));
}

let element =document.document.getElementById('username')
simulateMouseClick(element);


# Ví dụ:
var element1 = document.evaluate ('//input[@placeholder="Enter account name..."]', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
simulateMouseClick(element1);

var input1 = document.evaluate ('//input[@placeholder="Enter account name..."]', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
setNativeValue(input1, '5sj4k.wam');

var element2 = document.evaluate ('//button[@id="push-transaction-btn"]', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
simulateMouseClick(element2);

