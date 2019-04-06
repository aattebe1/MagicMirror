#include<stdio.h>
#include<string.h>
#include<curl/curl.h>
#include "libmagicmirror.h"

void DownloadXML(char fileName[], char url[]) {

	FILE *fp;

	/* Start libcurl easy session */
	CURL *curl = curl_easy_init();

	/* Proceed if libcurl easy session started successfully */
	if(curl) {

	    CURLcode receivedXml;

		fp = fopen(fileName, "wb");

		curl_easy_setopt(curl, CURLOPT_URL, url);
		curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, write_response);
		curl_easy_setopt(curl, CURLOPT_WRITEDATA, fp);

		receivedXml = curl_easy_perform(curl);

		curl_easy_cleanup(curl);

		fclose(fp);
	}
}

size_t write_response(void *ptr, size_t size, size_t nmemb, FILE *stream) {
    return fwrite(ptr, size, nmemb, stream);
}