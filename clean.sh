echo "Cleaning project files..."

sh clean-settings.sh && \
sh inject-device-name.sh "NewIrrigatorW" && \
sh inject-version.sh "1-0-0-1"

echo "Finished cleaning project files."