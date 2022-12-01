from socket import *
import threading

serverPort = 12055
serverSocket = socket(AF_INET, SOCK_DGRAM)
serverSocket.bind(("", serverPort))
print("The server is ready to receive")


def handleClient(connectionSocket, addr):
 sentence = connectionSocket.recv(1024).decode()
 print(sentence)
 capitalizedSentence = sentence.upper()
 connectionSocket.send(capitalizedSentence.encode())
 connectionSocket.close()
 threading.Thread(target= handleClient(), args = (connectionSocket, addr)).start()

while True:
    message, clientAddress = serverSocket.recvfrom(2048)
    modifiedMessage = message.decode().upper()
    serverSocket.sendto(modifiedMessage.encode(),
clientAddress)
