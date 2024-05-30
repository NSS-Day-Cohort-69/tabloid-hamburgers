const _apiUrl = "/api/tag";

export const getAllTags = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const deleteTagById = (Id) => {
  return fetch(`${_apiUrl}/${Id}`, { method: "DELETE" });
};

export const addATag = (tagObject) => {
  return fetch(`${_apiUrl}`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(tagObject),
  });
};
