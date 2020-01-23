

#!/bin/bash

# TO_DO:

# maybe add options to the script... 	# would use the 'case' statement.

#	-r	recursive option (no spaces in filenames)
#	-m	mp3 files only
#	-o	ogg files only
#	-s	spaces in filenames

# End TO_DO.

	set -e
	echo "Working..."
	LESSTHAN=0
	NOCHANGE=0
	MP3_TOTAL=$(find . -name "*.mp3" | wc -l)
	OGG_TOTAL=$(find . -name "*.ogg" | wc -l)
	MP3_AND_OGG=$(( $MP3_TOTAL + $OGG_TOTAL )) 
	
# choose SEARCH_METHOD ...

	# use this to recursively search directories
	# will not work if filenames have spaces!
	for FILENAME in $(find . -name "*.mp3" -o -name "*.ogg"); do

	# need to check for symbolic links here.
		#if [[ -f $FILENAME ]]

			#echo something

		#fi

# OR,

	# use this for directory specific,
	# or if filenames have spaces
	#find ./*.mp3 -print | while read FILENAME; do

# end choose SEARCH_METHOD.


		# test if audio file already has bitrate in filename?
		# here we use 'sed' to test the three characters before the
		# extension to see if they are numeric characters or not.
		# some songs will still fail here, like 'REM/Star69.mp3'
		while [[ `echo $FILENAME | sed 's/^.*\(...\)\..*/\1/'` != *[0-9]* ]]

			do

				break
				NOCHANGE=$(( $NOCHANGE + 1 ))

			done

		
		if [[ `echo $FILENAME | sed 's/^.*\(...\)\..*/\1/'` != *[0-9]* ]]; then

			# split filename into the 'base' and 'extenstion'
			BASENAME="${FILENAME%.[^.]*}"
			EXT="${FILENAME:${#BASENAME} + 1}"

			# mp3 or ogg
			if [[ $EXT = "mp3" ]]; then

				# is mp3 file a vbr?
				VBR=$(checkmp3 -v "$FILENAME" 2>/dev/null | \
					grep VBR_AVERAGE | cut -c 21-23) 

				if [[ -n "$VBR" ]]; then

					BITRATE=$VBR
					MP3_VBR_COUNT=$(( $MP3_VBR_COUNT + 1 ))

				else	# CBR

					BITRATE=$(checkmp3 -v "$FILENAME" 2>/dev/null | \
						grep BIT_RATE | cut -c 21-23)	
					MP3_CBR_COUNT=$(( $MP3_CBR_COUNT + 1 ))

				fi


				if [[ $BITRATE -lt 100 ]]; then

					# the '$COLOR' variable(s) come from ~/.bashrc
					LESSTHAN=$(( $LESSTHAN + 1 ))
					echo -e "$CYAN Bitrate is less than 100. $WHITE"
					BITRATE=0${BITRATE:0:2}

				fi

			elif [[ $EXT = "ogg" ]]; then 

			# Choose AVERAGE or NOMINAL bitrate!
			# FIX: make a test for OGG-VBR vs. OGG-CBR!
				
				# AVERAGE Bitrate
					#BITRATE=`ogginfo "$FILENAME" | \
						#grep "Average Bitrate" | cut -c 19-21`

			# OR, ->

				# NOMINAL bitrate
					BITRATE=`ogginfo "$FILENAME" | \
						grep "Nominal Bitrate" | cut -c 18-20`

			
			fi

			#echo -e "$BASENAME.$BITRATE.$EXT " #1>/dev/null
			# remove 'comment' below to ACTUALLY rename files			
			mv -Tv $FILENAME $BASENAME.$BITRATE.$EXT

		fi

	done

	echo	# intentional blank line

	if [[ $MP3_AND_OGG -ne 0 ]]; then	

		echo "    $MP3_AND_OGG	Audio Files"

	else

		echo >&2 "    Could not find any audio files!"
		exit 1

	fi



	if [[ $MP3_TOTAL -ne 0 ]]; then

		echo "    $MP3_TOTAL	MP3"

	fi



	if [[ $MP3_CBR_COUNT -ne 0 ]]; then

		echo "    $MP3_CBR_COUNT	CBR"

	fi



	if [[ $MP3_VBR_COUNT -ne 0 ]]; then

		echo "    $MP3_VBR_COUNT	VBR"

	fi



	if [[ $LESSTHAN -ne 0 ]]; then

		echo "    $LESSTHAN	Sub-Par!"

	fi



	if [[ $OGG_TOTAL -ne 0 ]]; then

		echo "    $OGG_TOTAL	OGG"

	fi



	if [[ $NOCHANGE -ne 0 ]]; then

		echo "    $NOCHANGE	unchanged"

	fi

exit 0
