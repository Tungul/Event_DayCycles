#!/bin/sh
rm Event_DayCycles.zip
apack Event_DayCycles.zip *
git add -A
git commit -m 'automated build and push'
git push