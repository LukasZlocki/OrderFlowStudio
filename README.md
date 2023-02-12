# OrderFlowStudio - Backend

Application to handle with production orders and its statuses during process steps.
For frontend app refer to link : https://github.com/LukasZlocki/OrderFlowStudioBlazor.Frontend

## General Information

In order to ensure a stable flow of the materials in factory, knowing statuses of producing materials on its process steps is essencial.
There are processes that takes hours to finish and not knowing the status of processing material can be confusing for Production Planers.
Production planners would like to know if the order is beeing started and processed what is a status for subprocesses.
The statuses are needed to estimate time of sending the order to next operations or directly to customer.

## The problem

The painting line and its process takes around 2.5 - 6 hours to process the order.
There is no feedback to Production Planist about order statuses that are being processes in the area.
The statusses essential for Production Planist are:
* is the order is started,
* is all pcs are processed correctly
* is the correction process needed for the order
* is the correction process finished for the order
* How many pcs are finished and ready to send to customer
Production planist get this feedback after 8 - 24 hours many times that cause problem with material flow planning due to:

## The solution:

The main idea is to collect order statuses of processing orders in couple stages in order to present clear overview for Production Planist
about orders and its stages statuses in process.
I have divided painting process into process stages and created web app to handle with order statuses basis on the process stages.
Process stages:
* Stage : Not in area		| checking if the order is present at painitng area.
* Stage : Not started		| registering order on painting line area. 
* Stage : Masking		| starting processing the order.
* Stage : Processing 		| starting painting process.
* Stage : Correction 		| starting correction process.
* Stage : Correction finished 	| raportitng finishing of  correction process.
* Stage : Almost done 		| starting process of finishing the order (fullfilling documents).
* Stage : Finished 		| raporting finishing the order.

## Branches

* main branch consist newest release.
* Release{number} branch covers all releases.

## Technologies Used

* C#
* .NET 6.0
* Web API

## Features

* Raporting stages of order in painiting line area.
* Searching the order by order number and showing its present status.
* Changing statuses of order by painting line operators.

## Creator

Created by Lukas Zlocki  
