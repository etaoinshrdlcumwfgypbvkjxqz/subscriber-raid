#!/bin/sh

# Do NOT change the replacement order!
# project GUID: bc9d47e4-823c-45aa-af25-f052eafee17f
# assembly GUID: 8ddcb5e9-86ba-49f1-9f4b-fe4a8f2a4567
for regexp in 's/VARIABLE_NAMESPACE/Polyipseity.SubscriberRaid/g' 's/VARIABLE_NAME/Subscriber Raid/g' 's/VARIABLE_ASSEMBLY_NAME/SubscriberRaid/g' 's/VARIABLE_AUTHOR/polyipseity/g' 's/VARIABLE_YEAR/2022/g' 's/VARIABLE_SUPPORTED_VERSION/1.3/g' 's/VARIABLE_DESCRIPTION//g' 's/VARIABLE_URL//g' 's/bc9d47e4-823c-45aa-af25-f052eafee17f/c63e5f3a-996e-43e4-aeee-674b65141c9e/g' 's/8ddcb5e9-86ba-49f1-9f4b-fe4a8f2a4567/a3793b77-2536-423b-b608-b42cb432df87/g'; do
	echo Applying \'$regexp\'…
	find . \( -type f -wholename "$0" \) -o \( -type d -name '.git' -prune \) -o -type f -print0 | xargs -0 sed -i "$regexp"
done
