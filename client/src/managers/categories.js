const _apiUrl = "/api/category";

export const getAllCategories = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const postNewCategory = (newCategory) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(newCategory),
  }).then((res) => res.json());
};
