using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using NAudio.Wave;
using AdventureEngine.AssetManagement.Assets;

namespace AdventureEngine.AssetManagement.Loading
{
    public class AssetLoader : IAssetLoader
    {
        protected Dictionary<string, string[]> _stagedFiles;

        public AssetLoader()
        {
            _stagedFiles = new Dictionary<string, string[]>();
        }

        public IAsset LoadAsset(string filePath, string id, ContentManager contentManager)
        {
            string[] fileContents;

            if (_stagedFiles.ContainsKey(filePath))
            {
                fileContents = _stagedFiles[filePath];
            }
            else
            {
                fileContents = File.ReadAllLines(filePath);
            }

            var asset = fileContents.Where(l => l.Length > 0)
                                    .Where(l => l.ToLower().StartsWith("asset"))
                                    .Where(l => l.ToLower().Contains(id))
                                    .Select(l => ParseAsset(l, contentManager))
                                    .FirstOrDefault();
            return asset;
        }

        public List<IAsset> LoadAssets(string filePath, ContentManager contentManager)
        {
            string[] fileContents;

            if (_stagedFiles.ContainsKey(filePath))
            {
                fileContents = _stagedFiles[filePath];
            }
            else
            {
                fileContents = File.ReadAllLines(filePath);
            }

            var assets = fileContents.Where(l => l.Length > 0)
                                     .Where(l => l.ToLower().StartsWith("asset"))
                                     .Select(l => ParseAsset(l, contentManager))
                                     .ToList();
            return assets;
        }

        public BaseAssetBatch LoadAssetBatch(string filePath, string id, IServiceProvider serviceProvider)
        {
            string[] fileContents;

            if (_stagedFiles.ContainsKey(filePath))
            {
                fileContents = _stagedFiles[filePath];
            }
            else
            {
                fileContents = File.ReadAllLines(filePath);
            }

            var batch = fileContents.Where(l => l.Length > 0)
                                    .Where(l => l.ToLower().StartsWith("assetbatch"))
                                    .Where(l => l.ToLower().Contains(id))
                                    .Select(l => ParseAssetBatch(l, serviceProvider))
                                    .FirstOrDefault();
            return batch;
        }

        public List<BaseAssetBatch> LoadAssetBatches(string filePath, IServiceProvider serviceProvider)
        {
            string[] fileContents;

            if (_stagedFiles.ContainsKey(filePath))
            {
                fileContents = _stagedFiles[filePath];
            }
            else
            {
                fileContents = File.ReadAllLines(filePath);
            }

            var batch = fileContents.Where(l => l.Length > 0)
                                    .Where(l => l.ToLower().StartsWith("assetbatch"))
                                    .Select(l => ParseAssetBatch(l, serviceProvider))
                                    .ToList();
            return batch;
        }

        public AudioAsset LoadAudioAsset(string filePath, string id, ContentManager contentManager)
        {
            string[] fileContents;

            if (_stagedFiles.ContainsKey(filePath))
            {
                fileContents = _stagedFiles[filePath];
            }
            else
            {
                fileContents = File.ReadAllLines(filePath);
            }

            var audioAsset = fileContents.Where(l => l.Length > 0)
                                         .Where(l => l.ToLower().StartsWith("asset"))
                                         .Where(l => l.ToLower().Contains(id))
                                         .Select(l => ParseAsset(l, contentManager))
                                         .Where(a => a is AudioAsset)
                                         .Select(a => a as AudioAsset)
                                         .FirstOrDefault();
            return audioAsset;
        }

        public SpriteFontAsset LoadSpriteFontAsset(string filePath, string id, ContentManager contentManager)
        {
            string[] fileContents;

            if (_stagedFiles.ContainsKey(filePath))
            {
                fileContents = _stagedFiles[filePath];
            }
            else
            {
                fileContents = File.ReadAllLines(filePath);
            }

            var spriteFontAsset = fileContents.Where(l => l.Length > 0)
                                              .Where(l => l.ToLower().StartsWith("asset"))
                                              .Where(l => l.ToLower().Contains(id))
                                              .Select(l => ParseAsset(l, contentManager))
                                              .Where(s => s is SpriteFontAsset)
                                              .Select(s => s as SpriteFontAsset)
                                              .FirstOrDefault();
            return spriteFontAsset;
        }

        public Texture2DAsset LoadTexture2DAsset(string filePath, string id, ContentManager contentManager)
        {
            string[] fileContents;

            if (_stagedFiles.ContainsKey(filePath))
            {
                fileContents = _stagedFiles[filePath];
            }
            else
            {
                fileContents = File.ReadAllLines(filePath);
            }

            var texuture2DAsset = fileContents.Where(l => l.Length > 0)
                                              .Where(l => l.ToLower().StartsWith("asset"))
                                              .Where(l => l.ToLower().Contains(id))
                                              .Select(l => ParseAsset(l, contentManager))
                                              .Where(t => t is Texture2DAsset)
                                              .Select(t => t as Texture2DAsset)
                                              .FirstOrDefault();
            return texuture2DAsset;
        }

        public void StageFile(string filePath, bool overwrite = false)
        {
            if (!_stagedFiles.ContainsKey(filePath))
            {
                var fileContents = File.ReadAllLines(filePath);
                _stagedFiles.Add(filePath, fileContents);
            }
            else if (overwrite)
            {
                var fileContents = File.ReadAllLines(filePath);
                _stagedFiles[filePath] = fileContents;
            }
        }

        public void UnstageFile(string filePath)
        {
            if (_stagedFiles.ContainsKey(filePath))
            {
                _stagedFiles.Remove(filePath);
            }
        }

        private IAsset ParseAsset(string assetDefinition, ContentManager contentManager)
        {
            IAsset asset = null;

            var arguments = assetDefinition.Split(';');

            // If the string provided is not an asset definition return null
            if (arguments[0].Trim().ToLower() != "asset")
                return null;

            var id = arguments[1];
            var parameters = arguments.Where(a => a.Contains('='));

            var type = "";
            var filePath = "";

            foreach (var p in parameters)
            {
                var pair = p.Split('=');

                switch (pair[0].Trim().ToLower())
                {
                    case ("type"):
                        { type = pair[1].Trim().ToLower(); }
                        break;
                    case ("filepath"):
                        { filePath = pair[1].Trim().ToLower(); }
                        break;
                }
            }

            switch (type.ToLower())
            {
                case ("texture2d"):
                    {
                        var texture = contentManager.Load<Texture2D>(filePath);
                        asset = new Texture2DAsset(id, texture);
                    }
                    break;
                case ("spritefont"):
                    {
                        var spriteFont = contentManager.Load<SpriteFont>(filePath);
                        asset = new SpriteFontAsset(id, spriteFont);
                    }
                    break;
                case ("audio"):
                    {
                        asset = new AudioAsset(id, new AudioFileReader(filePath));
                    }
                    break;
            }

            return asset;
        }

        private BaseAssetBatch ParseAssetBatch(string assetBatchDefinition, IServiceProvider serviceProvider)
        {
            var arguments = assetBatchDefinition.Split(';');

            // If the string provided is not an asset batch definition return null
            if (arguments[0].Trim().ToLower() != "assetbatch")
                return null;

            var id = arguments[1];
            var parameters = arguments.Where(a => a.Contains('='));

            var fileIdDict = new Dictionary<string, List<string>>();

            foreach (var p in parameters)
            {
                var pair = p.Split('=');
                var ids = pair[1].Trim()
                                 .Trim('{', '}')
                                 .Split(',')
                                 .ToList();
                fileIdDict.Add(pair[0], ids);
            }

            var batch = new BaseAssetBatch(id, serviceProvider);
            batch.FileIdDictionary = fileIdDict;

            return batch;
        }
    }
}