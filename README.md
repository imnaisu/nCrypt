# nCrypt

## Overview

**nCrypt Cipher** is a lightweight, console-based encryption and decryption tool designed to convert text strings into an unreadable, encoded format and to revert them back to their original form. This tool is ideal for basic data obfuscation needs, helping users protect sensitive information by transforming it into a secure, non-readable state.

The main goal of nCrypt Cipher is to provide an easy-to-use command-line utility for encoding and decoding text strings without requiring a complex setup or additional dependencies.

---

## Features

- Simple console interface for quick encryption and decryption  
- Supports both encryption and decryption modes with clear command-line flags  
- Converts plain text strings into encoded cipher text  
- Converts encoded cipher text back into the original readable string  
- No installation required; portable executable  

---

## Usage

You can use **nCrypt Cipher** to either encrypt or decrypt a string using the following options:

| Mode         | Command Format                                         | Description                       |
|--------------|--------------------------------------------------------|---------------------------------|
| Encrypt      | `nCrypt.exe -e "your_plain_text"`                      | Encrypts the plain text string   |
|              | `nCrypt.exe --encrypt "your_plain_text"`               | Alternative full option name     |
| Decrypt      | `nCrypt.exe -d "your_encoded_string"`                  | Decrypts the encoded string      |
|              | `nCrypt.exe --decrypt "your_encoded_string"`           | Alternative full option name     |

### Examples

#### Encrypt a String

```bash
nCrypt.exe -e "Hello World"
