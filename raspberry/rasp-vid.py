from datetime import datetime
from picamera import PiCamera
from time import sleep

camera = PiCamera()

dateName = datetime.now()  # Used to make filename unique

print(dateName)
camera.start_preview()
camera.start_recording(f"/home/pi/Desktop/{dateName}.h264")
sleep(5)
camera.stop_recording()
camera.stop_preview()
