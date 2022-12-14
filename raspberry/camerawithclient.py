# Code inspired from https://www.thepythoncode.com/article/send-receive-files-using-sockets-python
import socket
import tqdm
import os
from datetime import datetime
from picamera import PiCamera
from time import sleep
import string
import random

# Generates a random text string on 10 characters, that we use to name our files
s = 10
ran = ''.join(random.choices(string.ascii_uppercase + string.digits, k=s))

camera = PiCamera()

filename = f"/home/pi/SuperMuskler4000/SuperMuskler4000/raspberry/{ran}.h264"

# Camera records the file and saves it at filename location
camera.start_preview()
camera.start_recording(filename)
sleep(5)
camera.stop_recording()
camera.stop_preview()



SEPARATOR = "<SEPARATOR>"
BUFFER_SIZE = 4096  # send 4096 bytes each time step

# the ip address or hostname of the server, the receiver. (Your server's IP)
host = "192.168.14.239" #Currently using Anders'
# the port, let's use 12000
port = 12000



# This executes a terminal command that uses the ffmpeg program on the pi, which converts our 
# recording from .h264 to .mp4 and makes the rest of the code use the .mp4 version as filename
os.system(f"ffmpeg -i {filename} {ran}.mp4")
filename = f"/home/pi/SuperMuskler4000/SuperMuskler4000/raspberry/{ran}.mp4"







# get the file size
filesize = os.path.getsize(filename)

# create the client socket
s = socket.socket()

print(f"[+] Connecting to {host}:{port}")
s.connect((host, port))
print("[+] Connected.")


# send the filename and filesize
s.send(f"{filename}{SEPARATOR}{filesize}".encode())

# start sending the file
progress = tqdm.tqdm(range(filesize), f"Sending {filename}", unit="B", unit_scale=True, unit_divisor=1024)
with open(filename, "rb") as f:
    while True:
        # read the bytes from the file
        bytes_read = f.read(BUFFER_SIZE)
        if not bytes_read:
            # file transmitting is done
            break
        # we use sendall to assure transmission in
        # busy networks
        s.sendall(bytes_read)
        # update the progress bar
        progress.update(len(bytes_read))
# close the socket
s.close()
