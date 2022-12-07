from picamera import PiCamera
from time import sleep
from subprocess import call

camera = PiCamera()

camera.start_preview()
camera.start_recording("/home/pi/Desktop/videotest.h264")
sleep(5)
camera.stop_recording()
camera.stop_preview()
