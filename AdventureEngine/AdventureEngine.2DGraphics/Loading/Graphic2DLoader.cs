﻿using AdventureEngine.AssetManagement;
using AdventureEngine.Common.Extensions;
using AdventureEngine.Graphics2D.Assets;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventureEngine.Graphics2D.Loading
{
    public class Graphic2DLoader : IGraphic2DLoader
    {
        protected Dictionary<string, string[]> _stagedFiles;
        protected AssetManager _assetManager;

        public Graphic2DLoader(AssetManager assetManager)
        {
            _assetManager = assetManager;
        }

        public Text LoadText(string filePath, string id)
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

            var text = fileContents.Where(l => l.Trim().Length > 0)
                                      .Where(l => l.Trim().StartsWith("graphic"))
                                      .Where(l => l.ToLower().Contains("text"))
                                      .Where(l => l.Contains(id))
                                      .Select(l => ParseGraphic(l))
                                      .FirstOrDefault();
            return text as Text;
        }

        public Image LoadImage(string filePath, string id)
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

            var image = fileContents.Where(l => l.Trim().Length > 0)
                                      .Where(l => l.Trim().StartsWith("graphic"))
                                      .Where(l => l.ToLower().Contains("image"))
                                      .Where(l => l.Contains(id))
                                      .Select(l => ParseGraphic(l))
                                      .FirstOrDefault();
            return image as Image;
        }

        public Sprite LoadSprite(string filePath, string id)
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

            var sprite = fileContents.Where(l => l.Trim().Length > 0)
                                      .Where(l => l.Trim().StartsWith("graphic"))
                                      .Where(l => l.ToLower().Contains("sprite"))
                                      .Where(l => l.Contains(id))
                                      .Select(l => ParseGraphic(l))
                                      .FirstOrDefault();
            return sprite as Sprite;
        }

        public Effect LoadEffect(string filePath, string id)
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

            var effect = fileContents.Where(l => l.Trim().Length > 0)
                                      .Where(l => l.Trim().StartsWith("graphic"))
                                      .Where(l => l.ToLower().Contains("effect"))
                                      .Where(l => l.Contains(id))
                                      .Select(l => ParseGraphic(l))
                                      .FirstOrDefault();
            return effect as Effect;
        }

        public IGraphic2D LoadGraphic(string filePath, string id)
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

            var graphic = fileContents.Where(l => l.Trim().Length > 0)
                                      .Where(l => l.Trim().StartsWith("graphic"))
                                      .Where(l => l.Contains(id))
                                      .Select(l => ParseGraphic(l))
                                      .FirstOrDefault();
            return graphic;
        }

        public List<IGraphic2D> LoadGraphics(string filePath)
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

            var graphics = fileContents.Where(l => l.Trim().Length > 0)
                                       .Where(l => l.Trim().StartsWith("graphic"))
                                       .Select(l => ParseGraphic(l))
                                       .ToList();
            return graphics;
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

        private IGraphic2D ParseGraphic(string graphicDefinition)
        {
            BaseGraphic2D graphic = null;
            var arguments = graphicDefinition.Split(';');

            // If the string provided is not a graphic definition return null
            if (arguments[0].Trim().ToLower() != "graphic") return null;

            var id = arguments[1];
            var parameters = arguments.Where(a => a.Contains("="))
                                      .ToList();

            var type = "";

            foreach (var p in parameters)
            {
                var pair = p.Split('=');
                if (pair[0].Trim().ToLower() == "type")
                {
                    type = pair[1].Trim().ToLower();
                    break;
                }
            }

            switch (type.ToLower())
            {
                case ("text"): { graphic = ParseText(id, parameters); } break;
                case ("image"): { graphic = ParseImage(id, parameters); } break;
                case ("sprite"): { graphic = ParseSprite(id, parameters); } break;
                case ("effect"): { graphic = ParseEffect(id, parameters); } break;
            }

            return graphic;
        }

        private Text ParseText(string id, List<string> parameters)
        {
            var name = "";
            var spriteFontAssetId = "";
            Color color = new Color();
            Color disabledColor = new Color();
            Vector2 positionOffset = new Vector2();
            Vector2 dimensions = new Vector2();
            var fullText = "";

            foreach (var p in parameters)
            {
                var pair = p.Split('=');
                switch (pair[0].Trim().ToLower())
                {
                    case ("name"):
                        {
                            name = pair[1].ToLower();
                        }
                        break;
                    case ("spritefontassetid"):
                        {
                            spriteFontAssetId = pair[1].Trim().ToLower();
                        }
                        break;
                    case ("color"):
                        {
                            color = pair[1].Trim().ToLower().ToColor();
                        }
                        break;
                    case ("disabledcolor"):
                        {
                            disabledColor = pair[1].Trim().ToLower().ToColor();
                        }
                        break;
                    case ("positionoffset"):
                        {
                            positionOffset = pair[1].Trim().ToLower().ToVector2();
                        }
                        break;
                    case ("dimensions"):
                        {
                            dimensions = pair[1].Trim().ToLower().ToVector2();
                        }
                        break;
                    case ("fulltext"):
                        {
                            fullText = pair[1].ToLower();
                        }
                        break;
                }
            }

            var spriteFontAsset = _assetManager.GetSpriteFontAsset(spriteFontAssetId);
            if (spriteFontAsset == null)
            {
                spriteFontAsset = _assetManager.DefaultSpriteFontAsset;
            }

            return new Text(spriteFontAsset, color, disabledColor, positionOffset, dimensions, fullText);
        }

        private Image ParseImage(string id, List<string> parameters)
        {
            var name = "";
            var texture2DAssetId = "";
            Color color = new Color();
            Vector2 sourcePosition = new Vector2();
            Vector2 sourceDimensions = new Vector2();
            Vector2 positionOffset = new Vector2();
            Vector2 dimensions = new Vector2();
            var enabled = true;
            var visible = true;

            foreach (var p in parameters)
            {
                var pair = p.Split('=');
                switch (pair[0].Trim().ToLower())
                {
                    case ("name"):
                        {
                            name = pair[1].ToLower();
                        }
                        break;
                    case ("texture2dassetid"):
                        {
                            texture2DAssetId = pair[1].Trim().ToLower();
                        }
                        break;
                    case ("color"):
                        {
                            color = pair[1].Trim().ToLower().ToColor();
                        }
                        break;
                    case ("sourceposition"):
                        {
                            sourcePosition = pair[1].Trim().ToLower().ToVector2();
                        }
                        break;
                    case ("sourcedimensions"):
                        {
                            sourceDimensions = pair[1].Trim().ToLower().ToVector2();
                        }
                        break;
                    case ("positionoffset"):
                        {
                            positionOffset = pair[1].Trim().ToLower().ToVector2();
                        }
                        break;
                    case ("dimensions"):
                        {
                            dimensions = pair[1].Trim().ToLower().ToVector2();
                        }
                        break;
                    case ("enabled"):
                        {
                            enabled = pair[1].Trim().ToLower().ToBool();
                        }
                        break;
                    case ("visible"):
                        {
                            visible = pair[1].Trim().ToLower().ToBool();
                        }
                        break;
                }
            }

            var texture2DAsset = _assetManager.GetTexture2DAsset(texture2DAssetId);
            if (texture2DAsset == null)
            {
                texture2DAsset = _assetManager.DefaultTexture2DAsset;
            }

            return new Image(texture2DAsset, sourcePosition, sourceDimensions, color, positionOffset, dimensions, enabled, visible);
        }

        private Sprite ParseSprite(string id, List<string> parameters)
        {
            var name = "";
            var texture2DAssetId = "";
            Color color = new Color();
            Vector2 sourcePosition = new Vector2();
            Vector2 sourceDimensions = new Vector2();
            Vector2 positionOffset = new Vector2();
            Vector2 dimensions = new Vector2();
            var rows = 1;
            var columns = 1;
            var frameTime = -1;
            var looping = true;
            var enabled = true;
            var visible = true;

            foreach (var p in parameters)
            {
                var pair = p.Split('=');
                switch (pair[0].Trim().ToLower())
                {
                    case ("name"):
                        {
                            name = pair[1].ToLower();
                        }
                        break;
                    case ("texture2dassetid"):
                        {
                            texture2DAssetId = pair[1].Trim().ToLower();
                        }
                        break;
                    case ("color"):
                        {
                            color = pair[1].Trim().ToLower().ToColor();
                        }
                        break;
                    case ("sourceposition"):
                        {
                            sourcePosition = pair[1].Trim().ToLower().ToVector2();
                        }
                        break;
                    case ("sourcedimensions"):
                        {
                            sourceDimensions = pair[1].Trim().ToLower().ToVector2();
                        }
                        break;
                    case ("positionoffset"):
                        {
                            positionOffset = pair[1].Trim().ToLower().ToVector2();
                        }
                        break;
                    case ("dimensions"):
                        {
                            dimensions = pair[1].Trim().ToLower().ToVector2();
                        }
                        break;
                    case ("rows"):
                        {
                            rows = pair[1].Trim().ToLower().ToInt32();
                        }
                        break;
                    case ("columns"):
                        {
                            columns = pair[1].Trim().ToLower().ToInt32();
                        }
                        break;
                    case ("frametime"):
                        {
                            frameTime = pair[1].Trim().ToLower().ToInt32();
                        }
                        break;
                    case ("looping"):
                        {
                            looping = pair[1].Trim().ToLower().ToBool();
                        }
                        break;
                    case ("enabled"):
                        {
                            enabled = pair[1].Trim().ToLower().ToBool();
                        }
                        break;
                    case ("visible"):
                        {
                            visible = pair[1].Trim().ToLower().ToBool();
                        }
                        break;
                }
            }

            var texture2DAsset = _assetManager.GetTexture2DAsset(texture2DAssetId);
            if (texture2DAsset == null)
            {
                texture2DAsset = _assetManager.DefaultTexture2DAsset;
            }

            return new Sprite(texture2DAsset, sourcePosition, sourceDimensions, color, positionOffset, dimensions, rows, columns, frameTime, looping, enabled, visible);
        }

        private Effect ParseEffect(string id, List<string> parameters)
        {
            return new Effect();
        }
    }
}