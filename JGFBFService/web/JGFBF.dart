import 'dart:html';
import 'dart:json';

void main() {
  
  var http_request = new HttpRequest.get("http://localhost:3031/service/JGFBFTwitter.svc/TestInterface/TestContract", onSuccess);
   
}

void onSuccess(HttpRequest request)
{
  var response = request.responseText;
  List response_data = JSON.parse(response);
  for (Map pick in response_data)
  {
    StringBuffer sb = new StringBuffer();
    sb.add("<span style='margin-right:1em;'>User: ");
    sb.add(pick["User"]);
    sb.add("</span>");
    sb.add("<span>Player Picked: ");
    sb.add(pick["PlayerName"]);
    sb.add("</span><br/>");
    
    query("#container").appendHtml(sb.toString());
  }
}
