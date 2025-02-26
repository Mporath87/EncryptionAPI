using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EncryptionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptionController : ControllerBase
    {
        // Endpoint för kryptering
        [HttpGet("encrypt")]
        public IActionResult Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest("Text cannot be empty.");
            }

            string encryptedText = EncryptText(text);
            return Ok(encryptedText);
        }

        // Endpoint för avkryptering
        [HttpGet("decrypt")]
        public IActionResult Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest("Text cannot be empty.");
            }

            string decryptedText = DecryptText(text);
            return Ok(decryptedText);
        }

        // Enkel krypteringsmetod (Caesar-chiffer)
        private string EncryptText(string text)
        {
            StringBuilder encryptedText = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    encryptedText.Append((char)(((c + 3 - offset) % 26) + offset));
                }
                else
                {
                    encryptedText.Append(c);
                }
            }
            return encryptedText.ToString();
        }

        // Enkel avkrypteringsmetod (Caesar-chiffer)
        private string DecryptText(string text)
        {
            StringBuilder decryptedText = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    decryptedText.Append((char)(((c - 3 - offset + 26) % 26) + offset));
                }
                else
                {
                    decryptedText.Append(c);
                }
            }
            return decryptedText.ToString();
        }
    }
}