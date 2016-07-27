# 511 API Data Downloader
Downloads data from selected API endpoints to a timestamped xml file eg: BARTAlert-2016-07-19--07-49-13.xml

* **BaseAddress** points to http://transitservices.sfbay511.org/api or your localhost instance of https://github.com/metrotranscom/511_rtd-tdm
* **EndPoints** contains a list of the API's that will be appended to *BaseAddress* to construct the url.
* **SaveFilePath** points to the folder where the API data will be downloaded.