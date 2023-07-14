class NewMessage {
    constructor(chatId, messageText, user) {
        this.chatId = chatId;
        this.messageText = messageText;
        this.user = user;
    }
}

var connection = new signalR.HubConnectionBuilder().
    withUrl("/chat/ById/chathub").build();

connection.on('ReceiveMessage', function (chatId, fromUser, msg)
{
    var userNameVal = $('#userNameVal').val();
    if (fromUser === userNameVal) {
        var divWrapperMsg = document.createElement('div');
        divWrapperMsg.style = 'display:block; margin-left:auto; margin-right:5px';
        var divElem = document.createElement('div');
        divElem.className = 'card';
        divElem.innerHTML = msg;
        divElem.style = 'margin-left: 10px; margin-top: 10px; max-width: 150px; border: 1px solid blue; padding: 4px 4px 4px 4px';
        divWrapperMsg.appendChild(divElem);
        $('#' + chatId + '').find('#msgsContent').append(divWrapperMsg);
        $.post('/chat/AddMessage', new NewMessage(chatId, msg, fromUser));
    }
    else {
        var divWrapperMsg = document.createElement('div');
        divWrapperMsg.style = 'display:block; margin-left:5px; margin-right:auto';
        var mesg = fromUser + ': ' + msg;
        var divElem = document.createElement('div');
        divElem.className = 'card';
        divElem.innerHTML = mesg;
        divElem.style = 'margin-left: 10px; margin-top: 10px; max-width: 150px; border: 1px solid black; padding: 4px 4px 4px 4px';
        divWrapperMsg.appendChild(divElem);
        $('#' + chatId + '').find('#msgsContent').append(divWrapperMsg);
    }
});

connection.start().catch(error => {
    console.error(error.message)
});

function sendBtnHit(chatId, userNickname) {
    var textMsg = $('#txtMessage').val();

    connection.invoke('SendMessage', chatId, userNickname, textMsg);
}

