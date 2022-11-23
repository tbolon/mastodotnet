# Mastodotnet

# Development setup

This project uses devcontainer environment.

References:
- [Building a Dev Container for .NET Core](https://medium.com/swlh/building-a-dev-container-for-net-core-e43a2236504f)

# Local development, https and so much fun

Testing a service where a domain name with https is required is challenging.

The solution uses two concepts:

1. Allowing HTTPS to work on your local computer
2. Serving a custom non-routable domain (ex: mastodotnet.local) on 127.0.0.1 on the default port (80/443)

## Generating and trusting a certificate

The `.http` folder include a script `generate-self-signed.sh` that you can run to generate a custom certificate.
But a certificate has already been generated (with an expiration of 10 years), and can be installed on your computer.

You must trust this certificate on your browser.

#### Windows / Edge / Chrome

For edge/chrome/windows, you have to import the `mastodon.local.pfx` on your computer (password is `password`).
Keep the default settings, **but remember to mark the key as exportable for it to work with your reverse proxy (see point 2).**

### Firefox

TBD.

### Linux

TBD.

### MacOS

TBD.

###

## Serving mastodotnet.local

Depending on the configuration of your development machine, you will have to use differents steps.

The goal is always the same: proxy calls to `https://mastodotnet.local` to be served by `http://localhost:5000`.
Any solution could work.

### Windows

You have to edit the `%windir%\system32\drivers\etc\host` file to add a line with: `127.0.0.1 mastodotnet.local`.

Test: you should be able to ping `mastodotnet.local` on 127.0.0.1.

### Windows / IIS

If IIS is installed on your computer, you have no choice but to use it as a reverse proxy.

Install **ARR 3.0** and **URL Rewrite** module using Web Platform Installer if missing.
Then, add a new website with an https binding on mastodotnet.local, make it point to `.http/iis` folder on this project, and use the certificate trusted in 1) to secure the connection.
The iis folder already include a web.config file with a proxy.

First, check that the app is running and working on `http://localhost:5000`, then try to browse `https://mastodotnet.local`: you should see the same result.

### Windows / YARP

TBD.
