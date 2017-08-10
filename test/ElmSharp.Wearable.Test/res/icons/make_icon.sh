#!/bin/sh

OPTIND=1

while getopts "h?c:r:" opt; do
	case "$opt" in
		h|\?)
			echo "$0 [-c color] [-r degree]"
			exit 0
			;;
		c) color=$OPTARG
			;;
		r) rotate=$OPTARG
			;;
	esac
done

shift $((OPTIND-1))
filename=$1
iconname=$2

if [ -z $color ]; then
	color="white"
fi

if [ -z $rotate ]; then
	rotate=0
fi

if [ -z $toname ]; then
	iconname="icon_${color}_${rotate}_$filename"
fi

convert $filename -resize 75x75 \
	-stroke $color -fill none -draw "stroke-width 5 circle 37, 37, 60, 60" \
	\( +clone -threshold -1 -negate -fill white -draw "ellipse 37, 37 36, 36 4, 176 ellipse 37, 37, 36, 36 184, 356" \) \
	-distort SRT $rotate \
	-alpha off -compose copy_opacity -composite $iconname

