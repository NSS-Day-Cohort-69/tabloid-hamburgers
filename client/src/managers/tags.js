const _apiUrl = "/api/tag";

export const getAllTags = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const deleteTagById = (Id) => {
  return fetch(`${_apiUrl}/${Id}`, { method: "DELETE" });
};
