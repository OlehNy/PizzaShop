"use strict";

const connection = new signalR.HubConnectionBuilder()
	.withUrl("/orderHub")
	.build();