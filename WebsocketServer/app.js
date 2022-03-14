const WebSocket = require('ws');
const wss = new WebSocket.Server({ port:8080 });

wss.on('connection', function(ws) {
  console.log("client joined.");

  ws.on('message', function(data) {
    if (typeof(data) === "string") {
      console.log(`string received from client -> '${data}'`);
    } else {
      console.log(`binary received from client -> ${data.length} byte - Date/Time: ${new Date()}`);
      console.log("sending data to client...");
    }

    wss.clients.forEach(function each(client, isBinary) {
      if (client !== ws && client.readyState === WebSocket.OPEN) {
        client.send(data, { binary: isBinary });
      }
    });
  });

  ws.on('error', function(error) {
    console.log("Error...");
    console.log(error);
  });

  ws.on('close', function() {
    console.log("client left.");
  });
});
