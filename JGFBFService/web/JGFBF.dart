import 'dart:html';

void main() {
  
  var http_request = new HttpRequest.get("http://localhost:3031/service/JGFBFTwitter.svc/TestInterface/TestContract", onSuccess);
   
}

void onSuccess(HttpRequest request)
{
  query("#text").text = request.responseText;
}
